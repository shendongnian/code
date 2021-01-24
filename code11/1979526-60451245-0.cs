    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading;
    using System.Threading.Tasks.Dataflow;
    using System.Threading.Tasks;
    using System.Diagnostics;
    namespace Tests.Sets.Research
    {
        [TestClass]
        public class TPLTest
        {
            public class PipeLine
            {
                CancellationTokenSource cancellationTokenSource;
                TransformBlock<int, int> b1, b2;
                ActionBlock<int> bFinal;
                static int SimulateWork(String blockName, int message, CancellationTokenSource cancellationTokenSource)
                {
                    try
                    {
                        Thread.Sleep(100);
                        Trace.WriteLine($"{blockName} processed: {message}");
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine($"Fatal error {ex.Message} at {blockName}");
                        cancellationTokenSource.Cancel();
                    }
                    return message;
                }
                public PipeLine(CancellationTokenSource cancellationTokenSource)
                {
                    this.cancellationTokenSource = cancellationTokenSource;
                    // Create three TransformBlock<int, int> objects. 
                    // Each blocks <int, int> object calls the SimulateWork method.
                    Func<string, int, CancellationTokenSource, int> doWork = (name, message, ct) => SimulateWork(name, message, ct);
                    b1 = new TransformBlock<int, int>((m1) => doWork("b1", m1, cancellationTokenSource),
                       new ExecutionDataflowBlockOptions() { MaxDegreeOfParallelism = 1 , CancellationToken = cancellationTokenSource.Token}); //discard messages on  this block if cancel is signaled
                    b2 = new TransformBlock<int, int>((m1) => doWork("b2", m1, cancellationTokenSource), new ExecutionDataflowBlockOptions() { MaxDegreeOfParallelism = 1 });
                    bFinal = new ActionBlock<int>((m1) => doWork("bFinal", m1, cancellationTokenSource), new ExecutionDataflowBlockOptions() { MaxDegreeOfParallelism = 1 });
                    b1.LinkTo(b2, new DataflowLinkOptions { PropagateCompletion = true });
                    b2.LinkTo(bFinal, new DataflowLinkOptions { PropagateCompletion = true });
                }
                internal void Complete()
                {
                    b1.Complete();
                }
                public void waifForCompletetion()
                {               
                    Trace.WriteLine($"Waiting for pipeline to end gracefully");
                    bFinal.Completion.Wait();
                    Trace.WriteLine($"Pipeline terminated");               
                }
                public void submitToPipe(int message)
                {
                    if (cancellationTokenSource.IsCancellationRequested)
                    {
                        Trace.WriteLine($"Message {message} was rejected. Pipe is shutting down.Throtling meanwhile");
                        return;
                    }
                    b1.SendAsync(message);
                }
            }
            [TestMethod]
            public void TestShutdown()
            {
                var cancellationTokenSource = new CancellationTokenSource();
                var pipeLine = new PipeLine(cancellationTokenSource);
                //post failure in 2 seconds. 
                //It would be the same if was signal from inside block 2
                Task.Factory.StartNew(async () =>
                {
                    await Task.Delay(2000);
                    Console.WriteLine("Time to shutdown the pipeline!");
                    cancellationTokenSource.Cancel();
                });
                //send requests to pipe in background for 5 seconds
                Task.Run(async () =>
                {
                    for (int i = 1; i < 100; i++)
                    {
                        if (cancellationTokenSource.IsCancellationRequested)
                            break;
                        Thread.Sleep(50); //to see pipe closing input
                        pipeLine.submitToPipe(i);
                    }
                    pipeLine.Complete();
                });
                pipeLine.waifForCompletetion();
            }
        }
    }
 
