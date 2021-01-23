    namespace Serialize
    {
    class Program
    {
        static void Main(string[] args)
        {            
            List<Result> result = ;//Get From DB
            IFormatter formatter = new BinaryFormatter();
            Stream sStream = new FileStream(
                "SerializedList.bin",
                FileMode.CreateNew,
                FileAccess.Write,
                FileShare.None);
            formatter.Serialize(sStream, result);
            sStream.Close();           
        }
    }
