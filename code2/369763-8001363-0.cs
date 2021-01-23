    namespace App.Core.ReadModel
    {
        public class ReadModel
        {
        }
    }
    
    using App.Core.ReadModel;
    
    namespace App
    {
        public class Program
        {
            public static Main()
            {
                var obj = new ReadModel(); // ReadModel is a namespace
            }
        }
    }
