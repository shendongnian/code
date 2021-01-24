    public partial class Form1 : Form
    {
            int size = 0;
            Button[,] board = new Button[size,size];
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Button1_Click(object sender, EventArgs e)
            {
                random code that needs the board array
            }
            private void Form1_Click(object sender, EventArgs e)
            {
               other random code that need the board array
            }
            private void Form1_Load(object sender, EventArgs e)
            {
              size = int.Parse(Textbox1.Text);
            }
    
    }
