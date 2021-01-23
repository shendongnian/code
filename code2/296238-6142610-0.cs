    public class MyData
    {
        private static IList<MyData> _data { get; set; } 
        public static IList<MyData> Data 
        {    
            get
            {
                if (_data == null)
                   _data = load Big data struct from DB.
                return _data;
            }
        }
    }
