    [Serializable]
    public class Task
    {
        public string Name{get; set;}
        public string Location {get; set;}
        public string Arguments {get; set;}
        public DateTime RunWhen {get; set;}
    }
    public void WriteXMl(Task task)
    {
        XmlSerializer serializer;
        serializer = new XmlSerializer(typeof(Task));
        MemoryStream stream = new MemoryStream();
        StreamWriter writer = new StreamWriter(stream, Encoding.Unicode);
        serializer.Serialize(writer, task);
        int count = (int)stream.Length;
         byte[] arr = new byte[count];
         stream.Seek(0, SeekOrigin.Begin);
         stream.Read(arr, 0, count);
         using (BinaryWriter binWriter=new BinaryWriter(File.Open(@"C:\Temp\Task.xml", FileMode.Create)))
         {
             binWriter.Write(arr);
         }
     }
                
     public Task GetTask()
     {
         StreamReader stream = new StreamReader(@"C:\Temp\Task.xml", Encoding.Unicode);
         return (Task)serializer.Deserialize(stream);
     }
