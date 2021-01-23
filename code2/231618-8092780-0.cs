    public class FileHelper
    {
        public static void Delete(string path)
        {
            int attempts = 0;
            const int maxAttempts = 3;
            do
            {
                try
                {
                    attempts++;
                    File.Delete(path);
                    if (attempts > 1) Trace.TraceInformation("File delete succeeded");
                    return;
                }
                catch (IOException)
                {
                    Trace.TraceWarning("Could not access file for delete, attempt {0} of {1}", attempts, maxAttempts);
                    
                    if (attempts >= maxAttempts) throw;
                }
            }
            while (attempts < maxAttempts);
        }
    }
