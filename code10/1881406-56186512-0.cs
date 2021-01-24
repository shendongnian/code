    private async Task Copy(string startDirectory, string endDirectory, CancellationToken ct)
    {
        foreach (string dirPath in Directory.GetDirectories(startDirectory, "*", SearchOption.AllDirectories))
        {
            //Here we check if cancellation has been requesting if it has it will throw an exception (you can also check the IsCancellationRequested property and return) 
            ct.ThrowIfCancellationRequested();
            if (!SkipDirectory(dirPath))
            {
                Debug.Log("Creating directory " + dirPath);
                Directory.CreateDirectory(dirPath.Replace(startDirectory, endDirectory));
                foreach (string filename in Directory.EnumerateFiles(dirPath))
                {
                    try
                    {
                        using (FileStream SourceStream = File.Open(filename, FileMode.Open))
                        {
                            using (FileStream DestinationStream = File.Create(filename.Replace(startDirectory, endDirectory)))
                            {
                                await SourceStream.CopyToAsync(DestinationStream,81920, ct); //Pass cancellation token in to here and this can also handle cancellation
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        throw;
                    }
                    catch (System.Exception e)
                    {
                        Debug.LogWarning($"Inner loop:\t{filename}\t{e.Message}");
                    }
                }
            }
            else
            {
                Debug.Log("Skipping " + dirPath);
            }
        }
        foreach (string filename in Directory.EnumerateFiles(startDirectory))
        {
            //Here we check if cancellation has been requesting if it has it will throw an exception (you can also check the IsCancellationRequested property and return) 
            ct.ThrowIfCancellationRequested();
            try
            {
                using (FileStream SourceStream = File.Open(filename, FileMode.Open))
                {
                    using (FileStream DestinationStream = File.Create(endDirectory + filename.Substring(filename.LastIndexOf('\\'))))
                    {
                        await SourceStream.CopyToAsync(DestinationStream,81920, ct); //Pass cancellation token in to here and this can also handle cancellation
                    }
                }
            }
            catch(OperationCanceledException)
            {
                throw;
            }
            catch (System.Exception e)
            {
                Debug.LogWarning($"Outter loop:\t{filename}\t{e.Message}");
            }
        }
    }
