        protected void Page_Load(object sender, EventArgs e) {
    
     //Only fill it once on page load:
     if (!Page.IsPostBack) {
    
       getBankTable();
    
      string sql1 = "SELECT * FROM Master LEFT JOIN BANK ON Master.BANK_ID = Transaction.BANK_ID";
      OracleDataReader dr = cmd.ExecuteReader();
    
      while (dr.Read()) {
          if (dr["BANK_ID"] != null)
          {
               ddlBankName.Items.FindByValue(dr["BANK_ID"].ToString()).Selected = true;
          }      
      }
     }
    }
    
    public void getBankTable() {
     ddlBankName.Items.Clear();
    
     ddlBankName.Items.Insert(0, new ListItem("Select", ""));
     clsDataAccess cls = new clsDataAccess();
    
     string sql = "SELECT BANK_ID,BANK_DESC FROM Master";
    
     DataTable dt = cls.GetDataTable(sql);
    
     ddlBankName.DataTextField = "BANK_DESC";
     ddlBankName.DataValueField = "BANK_ID";
    
     ddlBankName.DataSource = dt;
     ddlBankName.DataBind();
    }
