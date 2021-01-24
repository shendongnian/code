    public class Component {
        public override string ToString()
        {
            return string.Format( "position:{0}, text:{1}", this.Position, this.Text );
        }
    
        public int Position { get; set; }
        public string Text { get; set; }
    }
    
    public class TextBoxComponent: Component {
        public override string ToString()
        {
             return base.ToString() + "type:\"textbox\"";
        }
    }
