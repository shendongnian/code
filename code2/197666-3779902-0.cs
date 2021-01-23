    Public string Text
    {
       get
       {
          EnsureChildControls();
          return textBox1.Text;
       }
       set
       {
          EnsureChildControls();
          textBox1.Text = value;
       }
    }
