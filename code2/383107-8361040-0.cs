    public Form1()
    {
        System.Data.SqlClient.SqlConnection con; 
       
        private void Form1_Load(object sender, EventArgs e) 
        { 
            con = new System.Data.SqlClient.SqlConnection(); 
        
            con.ConnectionString="Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Wee Jimmy\\Documents\\MyWorkers.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"; 
         
            con.Open(); 
         
            MessageBox.Show("Open"); 
         
            con.Close(); 
         
            MessageBox.Show("Closed"); 
        }
    }
