    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.bin";
            static void Main(string[] args)
            {
                Read_Write readWrite = new Read_Write();
                readWrite.CreateData(1000);
                readWrite.WriteData(FILENAME);
                readWrite.ReadData(FILENAME);
                readWrite.CreateDictionary();
            }
        }
        [Serializable()]
        public struct Data
        {
            public byte[] name;
            public byte[] data;
        }
        public class Read_Write
        {
            const int MIN_SIZE = 500;
            const int MAX_SIZE = 10000;
            public List<Data> data { get; set; }
            Dictionary<string, Data> dict = new Dictionary<string, Data>();
            public void CreateData(int numberRecords)
            {
                data = new List<Data>();
                for (int i = 0; i < numberRecords; i++)
                {
                    Data newData = new Data();
                    
                    string name = i.ToString() + '\0'; //null terminate string
                    newData.name = Encoding.UTF8.GetBytes(name);
                    Random rand = new Random();
                    int size = rand.Next(MIN_SIZE, MAX_SIZE);
                    newData.data = Enumerable.Range(0, size).Select(x => (byte)(rand.Next(0, 0xFF) & 0xFF)).ToArray();
                    data.Add(newData);
                }
            }
            public void WriteData(string filename)
            {
                Stream  writer = File.OpenWrite(filename);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(writer, data);
                
                writer.Flush();
                writer.Close();
            }
            public void ReadData(string filename)
            {
                Stream reader = File.OpenRead(filename);
                BinaryFormatter formatter = new BinaryFormatter();
                data = (List<Data>)formatter.Deserialize(reader);
                reader.Close();
            }
            public void CreateDictionary()
            {
                dict = data.GroupBy(x => GetString(x.name), y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
            public string GetString(byte[] characters)
            {
                int length = characters.ToList().IndexOf(0x00);
                return Encoding.UTF8.GetString(characters, 0, length);
            }
        }
    }
