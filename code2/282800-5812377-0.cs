    public class Test
        {
   
            public void testSerialize()
            {
                TestObj obj = new TestObj();
                obj.str = "Some String";
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, obj);
                formatter.Serialize(stream, 1);
                formatter.Serialize(stream, DateTime.Now);
                stream.Close();
            }
    
            public void TestDeserialize()
            {
                Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.None);
                IFormatter formatter = new BinaryFormatter();
                TestObj obj = (TestObj)formatter.Deserialize(stream);
                int obj2 = (int)formatter.Deserialize(stream);
                DateTime dt = (DateTime)formatter.Deserialize(stream);
                stream.Close();
            }
        }
    
        [Serializable]
        class TestObj
        {
            public string str = "1";
            int i = 2;
        }
