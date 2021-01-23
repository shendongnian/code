    public class ExceptionDetector : IDisposable
    {
        public void Dispose()
        {
            if (Marshal.GetExceptionCode()==0)
                Console.WriteLine("Completed Successfully!");
            else
                Console.WriteLine("Exception!");
        }
    }
