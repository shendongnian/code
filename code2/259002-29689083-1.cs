    using System.Collections.Generic;
    
    namespace DictionaryDataGridDemo
    {
        public class SingleDictViewModel
        {
            public Dictionary<double, string> MyDictionary { get; set; }
    
            public SingleDictViewModel()
            {
                MyDictionary = new Dictionary<double, string>();
                MyDictionary.Add(100, "A100");
                MyDictionary.Add(200, "B200");
                MyDictionary.Add(300, "C300");
            }
        }
    }
