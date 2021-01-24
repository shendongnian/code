    public class MyLovelyHorse
    {
       // private field of TextBox to play with internally
       private readonly TextBox _textbox;
    
    
       // constructor
       public MyLovelyHorse(TextBox textbox)
       {
          _textbox = textbox;
       }
    
       // some awesome method that does stuff
       public void SomeMethodThatDoesStuff()
       {
          _textbox.Text = "rah";
       }
    }
