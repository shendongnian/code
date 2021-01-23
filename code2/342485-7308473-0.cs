    public abstract class ConverterBase
    {
        public void Execute()
        {
            try
            {
                // Stuff
                ExecuteImpl();
            }
            finally
            {
                // Stuff
            }
        }
        protected abstract void ExecuteImpl();
    }
    public class Converter : ConverterBase
    {
        protected override void ExecuteImpl()
        {
            // Stuff to execute within the parent's try block
        }
    }
