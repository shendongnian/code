C#
public interface IUploader
{
    IResult Upload(string filePath);
}
public sealed class FileUploader
{
    IResult Upload(string filePath) { ... } // method is implemented as expected
}
public sealed class TestUploader //this is placed in a specific folder for test implementations
{
    public IResult ExpectedResult { get; set; } = Result.Success();
    IResult Upload(string filePath) => ExpectedResult;
}
To connect it with your class check the *Humble Object Design Pattern*. It explains how to extract testable logic from apparently untestable classes.
C#
void UploadToCloud(string filePath) 
{
    ...
    Uploader.Upload(filePath); // real implementation in production code, test implementation during unit testing.
    ...
}
I'd prefer going this way for multiple reasons:   
 - A change in the production code forces you to change the test implementation as well. With a Mock you would risk not to notice that your tests became obsolete.
 - A test implementation gives you more freedom (i.e. you can pass the test result to the test implementation in the initialization part of the test, to check edge cases).
 - It is cleaner than mocks and other developers can understand better what is going on. The tidier the code, the easier it is to keep it clean.
 - You still have some constraints given from the interface. Sometimes the Mock classes just become huge monsters that do not look like the original class anymore.
**NOTE**: If you want to test the receiving part, you can use the same strategy. Your test implementation will contain the expected content of the file, to test the cloud response.
