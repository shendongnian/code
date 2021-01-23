    MyFormMessageDialog : Form
    {
      public MyFormMessageDialog()
        {
            InitializeComponent();
        }
        public string name;
        public string adress;
        public string telephone;
         private void MyFormMessageDialog_Load(object sender, EventArgs e)
        {
            
            lblName.Text = name;
            lbladdress.Text = adress;
            telephone.Text telephone;
           //if you are saving ado.net stuff 
           //query username where name = name then bind it on a list box or a combo box 
           var Orderdata = //you retrieve info via DataTable;
           lstOder.Items.Clear();
           foreach (DataRow data in Orderdata.Rows)
                {
                    var lvi = new ListViewItem(data["Order"].ToString());
                    // Add the list items to the ListView
                    lstlstOder.Items.Add(lvi);
           }
      
        }
     }
