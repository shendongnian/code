    public void ShowMain()
        {
            if(auth()) // a method that returns true when the user exists.
            { 
                this.Close();
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(Main));
                t.Start();
            }
            else
            {
                MessageBox.Show("Invalid login details.");
            }         
        }
       [STAThread]
       public void Main()
       {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new Main());
    
       }
