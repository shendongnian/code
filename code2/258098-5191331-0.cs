    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
    
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);       
        }
    
        private void Form1_Paint(object sender, PaintEventArgs e)   
        {
            e.Graphics.DrawRectangle(Pens.Black, 10, 10, 100, 100);
        }
    }
