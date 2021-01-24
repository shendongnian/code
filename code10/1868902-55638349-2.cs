    public abstract class ConsoleReadType<T> where T: struct
    {
        public abstract T Read(T? min = null, T? max = null);
        public virtual T ReadUntilCorrect(T? min = null, T? max = null)
        {
            while (true)
            {
                try
                {
                    return Read(min, max);
                }
                catch (ConsoleInputException ciex)
                {
                    ConsoleWrite.Error(ciex.Message);
                }
            }
        }
    }
