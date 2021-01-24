C#
[Serializable] //Add this attribute above your class
public class FontInfo
{
   //...
}
Next try this simple example to see if your class serializes, saves to a file then deserializes.
C#
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public void Example()
{
     FontInfo fi = new FontInfo(){Size = 12};
     
     BinaryFormatter bf = new BinaryFormatter();
     // Serialize the Binary Object and save to file
     using (FileStream fsout = new FileStream("FontInfo.txt", FileMode.Create, FileAccess.Write, FileShare.None))
     {
            bf.Serialize(fsout, fi);
     }
     //Open saved file and deserialize
     using (FileStream fsin = new FileStream("FontInfo.txt", FileMode.Open, FileAccess.Read, FileShare.None))
     {
         FontInfo fi2 = (FontInfo)bf.Deserialize(fsin);
         Console.WriteLine(fi2.Size); //Should output 12
     }
}
This is just a quick example, but should get your started on the right track.
