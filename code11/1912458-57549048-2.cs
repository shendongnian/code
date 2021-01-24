c#
Encoding utf16 = Encoding.GetEncoding(864);
byte[] output = utf16.GetBytes(dataExport);
With:
c#
Encoding utf8 = new UTF8Encoding(true); //Include Preamble/Byte Order Mark
byte[] output = utf8.GetBytes(dataExport);
== Complete Example ==
The following C# code writes a .txt file with Arabic characters, which Excel correctly renders **when using File > Open to read the file**. As I noted in comments, Excel's drag-and-drop handler is broken and does not honor file encodings.
c#
using System.IO;
using System.Text;
namespace StackOverflow
{
    public class Program
    {
        const string TAB = "\t";
        public static string GetTabSeparatedValues()
        {
            var builder = new StringBuilder();
            builder.AppendFormat("{0}{1}{2}\r\n", "English", TAB, "Arabic");
            builder.AppendFormat("{0}{1}{2}\r\n", "al-nahw al-wafy", TAB, "النحو الوافي");
            return builder.ToString();
        }
        public static void WriteToUTF8(string filename, string data)
        {
            Encoding utf8 = new UTF8Encoding(true); //Include Preamble/Byte Order Mark
            byte[] output = utf8.GetBytes(data.ToString());
            using (FileStream FleSys = new FileStream(filename, FileMode.Create))
            using (BinaryWriter BinryWrtr = new BinaryWriter(FleSys))
            {
                BinryWrtr.Write(output, 0, output.Length);
            }
        }
        public static void Main(string[] args)
        {
            var data = GetTabSeparatedValues();
            WriteToUTF8("Test.txt", data);
        }
    }
}
