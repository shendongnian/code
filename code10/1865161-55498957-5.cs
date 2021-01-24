    public static void Main()
    {
        Mock<IFileManager> mockFileManager = new Mock<IFileManager>();
        string fakeFileContents = "Hello world";
        byte[] fakeFileBytes = Encoding.UTF8.GetBytes(fakeFileContents);
        
        MemoryStream fakeMemoryStream = new MemoryStream(fakeFileBytes);
    
        mockFileManager.Setup(fileManager => fileManager.StreamReader(It.IsAny<string>()))
                       .Returns(() => new StreamReader(fakeMemoryStream));
        
        Foo foo = new Foo(mockFileManager.Object);
        
        string result = foo.ParseFile("test.txt");
        
        Console.WriteLine(result);
    }
    
    public interface IFileManager
    {
        StreamReader StreamReader(string path);
    }
    
    public class Foo
    {
        IFileManager fileManager;
    
        public Foo(IFileManager fileManager)
        {
            this.fileManager = fileManager;
        }
    
        public string ParseFile(string filePath)
        {
            using (var reader = fileManager.StreamReader(filePath))
            {
                return reader.ReadToEnd();
            }
        }
    }
