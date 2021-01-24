c#
public interface IFileService {
    Task<string> PickUpFile();
}
public class FileService : IFileService {
    public async Task<string> PickUpFile() {
        // here you have your implementation
    }
}
// Here is the test method
public async Task TestTheService() {
    const string fileName = "filename.txt";
    var fileMocker = new Mock<IFileService>();
    fileMocker.Setup( x => x.PickUpFile() ).Returns( Task.FromResult( fileName ) );
    var mainClass = new MainClass( fileMocker.Object );
    await mainClass.OnLoadFileExecute( null );
    Assert.Equal( fileName, mainClass.FileLocation );
}
// here is the real class
public class MainClass {
    private IFileService FileService { get; }
    public string FileLocation { get; set; }
    public MainClass( IFileService fileService ) {
        FileService = fileService;
    }
    private async Task OnLoadFileExecute( object obj )
    {
        FileLocation = await FileService.PickUpFile();
        LoadedPhrases = LoadFromFile( FileLocation );
        PopulateDb( LoadedPhrases );
        LoadGroups();
    }
}
