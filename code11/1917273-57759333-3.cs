      public partial class Form1 : Form
      {
          private Test c;
          public Form1()
          {
            InitializeComponent();
            c = new Test(this); // This will _not_ create a new Form1 but pass this one.
            c.set_text("just some text");
          }
       }
