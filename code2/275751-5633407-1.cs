    public abstract class File {
        public abstract FileParameters Params { get; }
    }
    public abstract class FileIntermediate : File
    {
        public override FileParameters Params {get { return ParamsImpl; }}
        protected abstract FileParameters ParamsImpl { get; }
    }
    public class SpecialFile : FileIntermediate
    {
        public new SpecialFileParameters Params { get { return null; } }// TODO 
        protected override FileParameters ParamsImpl {get { return Params; }}
    }
