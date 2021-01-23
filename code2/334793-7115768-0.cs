    public interface ICommandLineRunner
    {
    	string RunCommand(string command);
    }
    
    public class CLIService
    {
       private readonly ICommandLineRunner _cliRunner;
       public CLIService(ICommandLineRunner cliRunner)
       {
           _cliRunner = cliRunner;
       }
    
       public string GetVersionNumber()
       {
           string output = _cliRunner.RunCommand("-version");
           //Parse output and store in result
           return result;        
       }
    }
    
    [Test]
    publc void Test_Gets_Version_Number()
    {
    	var mockCLI = new Mock<ICommandLineRunner>();
    	mockCLI.Setup(a => a.RunCommand(It.Is<string>(s => s == "-version"))
           .Returns(File.ReadAllText("version-number-output.txt"));
    
    	var mySvc = new CLIService(mockCLI.Object);
    	var result = mySvc.GetVersionNumber();
    	Assert.AreEqual("1.0", result);
    }
