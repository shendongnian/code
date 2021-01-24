c#
class Program
{
    //     !!!!!! add this
    public static byte[] StreamFile(string filename)
    {
        FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
        // Create a byte array of file stream length
        byte[] ImageData = new byte[fs.Length];
        //Read block of bytes from stream into the byte array
        fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));
        byte[] bytes = System.IO.File.ReadAllBytes(filename);
        //Close the File Stream
        fs.Close();
        return ImageData; //return the byte data
    }
    static void Main(string[] args)
    {
        StreamFile(@"");
    }
}
You can rewrite your code and make it more robust in this way (.net core)
c#
class Program
{
    public static byte[] StreamFile(string filename)
    {
        byte[] data;
        // let the stream be managed on its own
        using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            // If you want to ask for the length of the file, be sure nobody is changing it over time. See the FileShare.Read above
            data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
        }
        return data;
    }
    static void Main(string[] args)
    {
        StreamFile(@"");
    }
}
Please note that the `using` construct automatically closes/disposes the resource you are using when it goes out of scope<sup>1</sup>. This way you cannot make mistakes and it is clear what is your intent.
You must lock the file (in your case, just asking nobody can change it via `FileShare.Read`) otherwise you may have a race condition on the file since you might read an inconsistent data.
---
<sup>1</sup> They must implement the `IDisposable` interface.
