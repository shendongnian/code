    public class TypewriterText
    {
        public IEnumerable<ITypewriterTextAction> TextActions {get;set;}
    }
    public enum TypeWriterTextActionType
    {
        Plain,
        Replace
    }
    public interface ITypewriterTextAction
    {
        TypeWriterTextActionType ActionType {get;}
    }
    public class PlainTypeWriterTextAction : ITypewriterTextAction
    {
        public TypeWriterTextActionType ActionType 
        {
            get {return TypeWriterTextActionType.Plain;
        }
        public string TextToWrite {get;set;}
    }
    public class ReplaceTypeWriterTextAction : ITypewriterTextAction
    {
        public TypeWriterTextActionType ActionType 
        {
            get {return TypeWriterTextActionType.Replace;
        }
        public string OriginalText {get;set;}
        public string ReplacementText {get;set;}
    }
    
