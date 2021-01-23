    public class ExecuteHelper
    {
        public static void Catch(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                // Do what you want
            }
        }
    }
