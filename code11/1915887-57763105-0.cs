 csharp
[TestClass]
public class FileClass
{
    [TestMethod]
    [DataRow("somefile", 3, 345, 333)]
    [DataRow("anotherfile", 4, 291, 330)]
    public void Output1IsValid(string fileName, int parameter, int resultX, int resultY) 
    { 
        var fileParseResult = FileParser.ParseFile(fileName);
        Assert.AreEqual(fileParseResult.Item1, resultX);         
    }
        
}
