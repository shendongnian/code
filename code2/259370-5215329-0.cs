    public class MyTextBox:TextBox
    {
       [EditorBrowsable(EditorBrowsableState.Never)]     
       [Browsable(false)]
        public new string Text
        {
          get
          {
             return base.Text;
          }
          set
          {
            base.Text = value;
          }
        }
    }
