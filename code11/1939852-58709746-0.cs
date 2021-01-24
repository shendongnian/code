    SqlConnection cn = new SqlConnection();
    SqlCommand cm = new SqlCommand();
    DBConnection dbcon = new DBConnection();
    SqlDataReader dr;
    frmProductList flist;
    public frmProduct(frmProductList frm)
    {
        InitializeComponent();
        cn = new SqlConnection(dbcon.MyConnection());
      flist = frm; 
    }
