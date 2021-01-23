    namespace ConsoleApplication1
    {
        [Serializable]
        class MyItem
        {
            public int MyProperty { get; set; }
            public MyItem RefTo { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                List<MyItem> list1 = new List<MyItem>();
                list1.Add(new MyItem() { MyProperty = 1 });
                list1.Add(new MyItem() { MyProperty = 2 });
                list1.Add(new MyItem() { MyProperty = 3 });
    
                list1[1].RefTo = list1[0];
                list1[2].RefTo = list1[1];
    
                using (MemoryStream stream = new MemoryStream())
                {
                    var bformatter = new BinaryFormatter();
                    bformatter.Serialize(stream, list1);
                    stream.Seek(0, SeekOrigin.Begin);
                    List<MyItem> clonedCopyList = (List<MyItem>)bformatter.Deserialize(stream);
                }
            }
        }
    }
