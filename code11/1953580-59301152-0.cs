     public struct MyLogText {
       public MyLogText(string text, bool overwrite) {
         //TODO: you may want to validate the text
         Text = text;
         Overwrite = overwrite; 
       }
       public string Text {get;}  
       public bool Overwrite {get;}   
       //TODO:You may want add ToString(), Equals, GetHashcode etc. methods
     }
