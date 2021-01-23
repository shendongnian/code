      public partial class Form1 : Form
      {
        static int msgCounter = 1;
        public Form1()
        {
          InitializeComponent();
          button1.Click += new EventHandler(button1_Click);
        }
    
        void button1_Click(object sender, EventArgs e)
        {
          switch (msgCounter)
          {
            case 1:
              {
                richTextBox1.Text = "first click";
                msgCounter++;
              }
              break;
            case 2:
              {
                richTextBox1.Text = "second click";
              }
              break;
            default: this.Close(); break;
          }
        }    
      }
