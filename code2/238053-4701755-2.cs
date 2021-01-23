    class Form2
    {
      // Form2.designer.cs
      private TextBox TextBox1;
      // Form2.cs
      public String TextBoxValue // retrieving a value from
      {
        get
        {
          return this.TextBox1.Text;
        }
      }
      public Form2(String InitialTextBoxValue) // passing value to
      {
        IntiializeComponent();
        
        this.TextBox1.Text = InitialTextBoxValue;
      }
    }
