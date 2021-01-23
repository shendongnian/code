    public class B
    {
        static string _GetSourceFileName()
        {
            return new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        }
    }
