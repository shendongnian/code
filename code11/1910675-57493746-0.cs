attachment.SaveAsFile(GetConfigSettings("folderPath") + "\\"+ currentTime + "_" + attachment.FileName);
System.Threading.Thread.Sleep(100);
using (BinaryReader br = new BinaryReader(File.Open(GetConfigSettings("folderPath") + "\\"+ currentTime + "_" + attachment.FileName), FileMode.Open)))
{
fileSize = br.BaseStream.Length.ToString();
}
