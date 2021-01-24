    // add where T: struct so that only structs (int, double, etc) can be used
    // allows you to use T? 
    public abstract class ConsoleReadType<T> where T: struct
    {
        public abstract T Read();
        public abstract T Read(T? min, T? max);
        public virtual T ReadUntilCorrect(Func<T> FunctionToRun, string message = "")
        {
            while (true)
            {
                try
                {
                    return FunctionToRun();
                }
                catch (ConsoleInputException)
                {
                    if (!string.IsNullOrEmpty(message))
                        ConsoleWrite.Error(message);
                }
            }
        }
    }
