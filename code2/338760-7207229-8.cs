    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<String> liAddresses = new List<String>();
            //Define list of addresses for demonstration purposes
            //Replace with fetch from DB
            for (int i = 1; i <= 50; i++)
            {
                liAddresses.Add(i.ToString() + "user@domain.com");
            }
            //Load TextBox with list of addresses, will render as <textarea>
            foreach (String strAddress in liAddresses)
            {
                TextBox1.Text += strAddress + "\r\n";
             
            }
        }
    }
