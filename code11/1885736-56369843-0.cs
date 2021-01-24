    public class MyLovelyHorse
    {
        // private field of TextBox to play with internally
        private TextBox _textbox;
    
        // ShortHand constructor with one parameter of TextBox 
        public MyLovelyHorse(TextBox textbox) => _textbox = textbox;
    
        // another way to write a constructor (probably more usual)
        // public MyLovelyHorse(TextBox textbox)
        // {
        //    _textbox = textbox
        // }
        // some awesome method that does stuff
        public SomeMethodThatDoesStuff()
        {
            _textbox.Text = "rah";
        }
    }
