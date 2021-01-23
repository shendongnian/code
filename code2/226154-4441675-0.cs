    public class Processor
        {
            private Dictionary<string,FileParserBase> _fileExtension2FileParser;
    
            public Processor() {
                _fileExtension2FileParser = new Dictionary<string, FileParserBase>();
    
                AddParser(new DocExtensionWordParser());
                AddParser(new DocXExtensionWordParser());
                //..more,more
            }
    
            private void AddParser(FileParserBase fileParserBase) {
    
                _fileExtension2FileParser.Add(fileParserBase.Extension, fileParserBase);
            }
    
            
        public void Process(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            FileParserBase fileParser;
            if (_fileExtension2FileParser.TryGetValue(extension, out fileParser)) {
                fileParser.Process(fileName);
            }
            
        }
        }
    
        public abstract class FileParserBase
        {
            public abstract string Extension { get; }
            public abstract void Process(string filePath);
        }
    
        public abstract class WordParserBase : FileParserBase
        {
            private string _extension;
    
            public WordParserBase(string extension)
            {
                _extension = extension;
            }
    
            public override void Process(string filePath)
            {
                //Do the processing for WORD Document
            }
    
            public override string Extension
            {
                get { return _extension; }
            }
        }
    
        public class DocExtensionWordParser : WordParserBase
        {
        
            public DocExtensionWordParser():base("doc"){}
        }
    
        public class DocXExtensionWordParser : WordParserBase
        {
    
            public DocXExtensionWordParser() : base("docx") { }
        }
