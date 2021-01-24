    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    //...
    public static async Task ProcessFile(string sourcePath, Encoding sourceEncoding,
        string targetPath, Encoding targetEncoding,
        Func<string, string> lineTransformation,
        int degreeOfParallelism, int chunkSize)
    {
        using StreamWriter writer = new StreamWriter(targetPath, false, targetEncoding);
        var cts = new CancellationTokenSource();
        var processingBlock = new TransformBlock<IList<string>, IList<string>>(chunk =>
        {
            return chunk.Select(line => lineTransformation(line)).ToArray();
        }, new ExecutionDataflowBlockOptions()
        {
            MaxDegreeOfParallelism = degreeOfParallelism,
            BoundedCapacity = 100, // prevent excessive buffering
            EnsureOrdered = true, // this is the default, but lets be explicit
            CancellationToken = cts.Token, // have a way to abort the processing
        });
        var writerBlock = new ActionBlock<IList<string>>(chunk =>
        {
            foreach (var line in chunk)
            {
                writer.WriteLine(line);
            }
        }); // The default options are OK for this block
        // Link the blocks and propagate completion
        processingBlock.LinkTo(writerBlock,
            new DataflowLinkOptions() { PropagateCompletion = true });
        // In case the writer block fails, the processing block must be canceled
        OnFaultedCancel(writerBlock, cts);
        static async void OnFaultedCancel(IDataflowBlock block, CancellationTokenSource cts)
        {
            try
            {
                await block.Completion.ConfigureAwait(false);
            }
            catch
            {
                cts.Cancel();
            }
        }
        // Feed the processing block with chunks from the source file
        await Task.Run(async () =>
        {
            try
            {
                var chunks = File.ReadLines(sourcePath, sourceEncoding)
                    .Buffer(chunkSize);
                foreach (var chunk in chunks)
                {
                    var sent = await processingBlock.SendAsync(chunk, cts.Token)
                        .ConfigureAwait(false);
                    if (!sent) break; // Happens in case of a processing failure
                }
                processingBlock.Complete();
            }
            catch (OperationCanceledException)
            {
                processingBlock.Complete(); // Cancellation is not an error
            }
            catch (Exception ex)
            {
                // Reading error
                // Propagate by completing the processing block in a faulted state
                ((IDataflowBlock)processingBlock).Fault(ex);
            }
        }).ConfigureAwait(false);
        // All possible exceptions have been propagated to the writer block
        await writerBlock.Completion.ConfigureAwait(false);
    }
