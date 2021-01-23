    public class Program
    {
        public static Form1 YourForm; 
        [STAThread]
        static void Main(string[] args)
        {
            using (Form1 mainForm = new Form1())
            {
                YourForm = mainForm;
                Application.Run(mainForm);
            }
            YourForm = null;
        }
    }
