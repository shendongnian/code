    public partial class Form1 : Form
    {
        private people viktor;
        private people julia;
        public Form1()
        {
            InitializeComponent();
            viktor = new people() { Cash = 1000, LastName = "Jushenko" };
            julia = new people() { Cash = 500, LastName = "Timoshenko" };
        }
