    public partial class MyObject
    {
        public static MyObject Deserialize(string xmlInputFile)
        {
            MyObject myobject;
            //INSERT CODE HERE THAT RUNS BEFORE DESERIALIZATION
            using (StreamReader sr = new StreamReader(xmlInputFile))
            {
                XmlSerializer xs = new XmlSerializer(typeof (MyObject));
                myobject = (MyObject) xs.Deserialize(sr);
                sr.Close();
            }
            //INSERT CODE HERE THAT RUNS AFTER DESERIALIZATION
            return myobject;
        }
    }
