    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        class Board
        {
            private TextBox[,] textboxes;
    
            public Board(Form1 form)
            {
                textboxes = new TextBox[,] 
                {
                    {form.textBox1, form.textBox2, ....}
                };
            }
        }
    }
