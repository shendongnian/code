    namespace App.Core.ReadModel
    {
        public class ReadModel
        {
        }
    }
    
    using App.Core.ReadModel; // cannot be placed here. Must be at top of file.
    
    namespace App
    {
        public class Program
        {
            public static Main()
            {
                var obj = new ReadModel();
            }
        }
    }
