using System;
using System.IO;
using System.Net;
namespace ReadBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            string fname = "myfile.bin";
            try
            {
                Console.WriteLine("Opening " + fname + "...");
                BinaryReader br =
                  new BinaryReader(
                        File.Open(fname, FileMode.Open));
                for (int i = 0; i &lt; (int)(br.BaseStream.Length / 4); i++)
                {
                    int j =
                        System.Net.IPAddress.NetworkToHostOrder (br.ReadInt32());
                    Console.WriteLine("array[" + i + "]=" + j + "...");
                }
                br.Close();
                Console.WriteLine("Read complete.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("I/O error" + ex.Message);
            }
        }
    }
}
