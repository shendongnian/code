     public struct MyLogText {
       public MyLogText(string text, bool overwrite) {
         //TODO: you may want to validate the text
         Text = text;
         Overwrite = overwrite; 
       }
       public string Text {get;}  
       public bool Overwrite {get;}   
       // Let's add some syntax sugar: tuples
       public MyLogText((string, bool) tuple)
         : this(tuple.Item1, tuple.Item2) { }
       public void Deconstruct(out string text, out bool overwrite) {
         text = Text;
         overwrite = Overwrite;
       }
       public static implicit operator MyLogText((string, bool) tuple) => new MyLogText(tuple);
       //TODO:You may want add ToString(), Equals, GetHashcode etc. methods
     }
