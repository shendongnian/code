    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp9
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.Run(new Form1());
            }
        }
    }
