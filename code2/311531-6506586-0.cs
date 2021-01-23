    static class Program
    {
        [STAThread]
        static void Main()
        {
            var loader = new Loader();
            Application.Run(loader);
        }
    }
    
    public class Loader : Form 
    {
        public Loader()
        {
            InitializeComponent();
            Main win = new Main();
            win.Show();
            this.Hide();
        }
    
    }
    
    public class Main : Form 
    {
        
    }
