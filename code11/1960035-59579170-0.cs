    public sealed class RunTimeCore
    {
        public static string GetString()
        {
            return TestLib.TestTool.GetString();
        }
    }
    
    
    public class TestTool
    {
        public static string GetString() {
    
            return "hello";
        }
    }
