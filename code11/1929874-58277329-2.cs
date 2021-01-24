    using System;
    using System.IO;
    using System.Text;
    
    public class FSSeek
    {
        public static void Main()
        {
            string fileName = "test.txt";
            char lastChar = ']';
            string toBeAppend = "d\ne\n";
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                fs.Seek(-1, SeekOrigin.End);
                if ( Convert.ToChar(fs.ReadByte()) == lastChar ){
                    fs.SetLength(fs.Length - 1);
                    fs.Write(Encoding.ASCII.GetBytes(toBeAppend));
                    fs.WriteByte(Convert.ToByte(lastChar));
                }            
                
            }
        }
    }
