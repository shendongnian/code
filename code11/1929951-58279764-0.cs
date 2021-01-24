    internal interface IFileWriter
    {
        void Write(string text);
    }
Two classes implementing the IFileWriter
    internal class AWSWriter : IFileWriter
    {
        public void Write(string text)
        {
            //Write to AWS
        }
    }
    internal class DiskDriveWriter : IFileWriter
    {
        public void Write(string text)
        {
            //Write to disk
        }
    }
Abstract Base class for the adapter
    public abstract class AbstractFileWriterAdapter
    {
        internal IFileWriter FileWriter { get; set; }
    }
Two adapters, one for AWS and another for the DiskWriter
    public class AWSFileWriterAdapter: AbstractFileWriterAdapter
    {
        public AWSFileWriterAdapter()
        {
            FileWriter = new AWSWriter();
        }
    }
    public class DiskDriveWriterAdapter:AbstractFileWriterAdapter
    {
        public DiskDriveWriterAdapter()
        {
            FileWriter = new DiskDriveWriter();
        }
    }
WriterService
    public class WriterService
    {
        AbstractFileWriterAdapter _writer;
        public WriterService(AbstractFileWriterAdapter writer)
        {
            _writer = writer;
        }
        public void WriteMessage(string text)
        {
            _writer.FileWriter.Write(text);
        }
    }
**Finally the calls from a different project**
            var awsAdapter = new AWSFileWriterAdapter();
            var service1 = new WriterService(awsAdapter);
            service1.WriteMessage("Some fancy text to AWS!!");
            var diskDriveAdapter = new DiskDriveWriterAdapter();
            var service2 = new WriterService(diskDriveAdapter);
            service2.WriteMessage("Some text to the drive!!");
