    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Runtime.InteropServices;
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
                Data data = readWrite.GetRecord(FILENAME, "101");
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
            [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern int memcmp(byte[] b1, byte[] b2, long count);
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
                Stream writer = File.OpenWrite(filename);
                //write number of records
                byte[] numberOfRecords = BitConverter.GetBytes((int)data.Count());
                writer.Write(numberOfRecords, 0, 4);
                foreach (Data d in data)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(writer, d);
                }
                writer.Flush();
                writer.Close();
            }
            public Data GetRecord(string filename, string name)
            {
                Data record = new Data();
                Stream reader = File.OpenRead(filename);
                byte[] numberOfRecords = new byte[4];
                reader.Read(numberOfRecords, 0, 4);
                int records = BitConverter.ToInt32(numberOfRecords, 0);
                for(int i = 0; i < records; i++)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    Data d = (Data)formatter.Deserialize(reader);
                    if (name == GetString(d.name))
                    {
                        record = d;
                        break;
                    }
                }
                reader.Close();
                return record;
            }
            public string GetString(byte[] characters)
            {
                int length = characters.ToList().IndexOf(0x00);
                return Encoding.UTF8.GetString(characters, 0, length);
            }
        }
    }
