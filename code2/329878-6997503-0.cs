    class Document
    {
       private List<string> _textArray = new List<string>();
       public void Write(string text)
       {
           _textArray.Add(text);
       }
       public void Erase(string text)
       {
           _textArray.Remove(text);
       }
       public void Erase(int textLevel)
       {
           _textArray.RemoveAt(textLevel);
       }
       public string ReadDocument()
       {
           System.Text.StringBuilder sb = new System.Text.StringBuilder();
           foreach(string text in _textArray)
               sb.Append(text);
           return sb.ToString();
       }
    }
    abstract class Command
    {        
       abstract public void Redo();
       abstract public void Undo();
    }
    class DocumentEditCommand : Command
    {
       private Document _editableDoc;
       private string _text;
       public DocumentEditCommand(Document doc, string text)
       {
           _editableDoc = doc;
           _text = text;
           _editableDoc.Write(_text);
        }
       override public void Redo()
       {
           _editableDoc.Write(_text);
       } 
       override public void Undo()
       {
           _editableDoc.Erase(_text);
       }
    }
    class DocumentInvoker
    {
       private List<Command> _commands = new List<Command>();
       private Document _doc = new Document();
       public void Redo( int level )
       {
           Console.WriteLine( "---- Redo {0} level ", level );
           ((Command)_commands[ level ]).Redo();
       }
       public void Undo( int level )
       {
           Console.WriteLine( "---- Undo {0} level ", level );
           ((Command)_commands[ level ]).Undo();
       }
       public void Write(string text)
       {
           DocumentEditCommand cmd = new 
           DocumentEditCommand(_doc,text);
           _commands.Add(cmd);
       }
    
       public string Read()
       {
          return _doc.ReadDocument();
       }
    }
