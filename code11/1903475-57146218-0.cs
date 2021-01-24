  protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            load();
        }
    }
**load()** 
protected void load()
    {
     if (ViewState["CurrentData"] == null)
      {
       DataTable dt = (DataTable)ViewState["CurrentData"];
       BindGrid(1);
      }
    }
**BindGrid()**
 private void BindGrid(int rowcount)
    {
            DataTable dt = new DataTable();
            DataRow dr;
            DataColumn RcAccCode, RcAccAccount, RcAmount, RcAccId;
            int temp = 0;
            int a = 0;
            RcAccCode = new DataColumn("RcAccCode", Type.GetType("System.String"));
            RcAccAccount = new DataColumn("RcAccAccount", Type.GetType("System.String"));
            RcAmount = new DataColumn("RcAmount", Type.GetType("System.String"));
            RcAccId = new DataColumn("RcAccId", Type.GetType("System.String"));
            dt.Columns.Add(RcAccCode);
            dt.Columns.Add(RcAccAccount);
            dt.Columns.Add(RcAmount);
            dt.Columns.Add(RcAccId);
            TextBox TextBox1 = new TextBox();
            TextBox TextBox2 = new TextBox();
            TextBox TextBox3 = new TextBox();
                if (ViewState["CurrentData"] != null)
                {
                    dt = (DataTable)ViewState["CurrentData"];
                    if (dt.Rows.Count > 0)
                    {
                        dr = dt.NewRow();
                        dr[0] = dt.Rows[0][0].ToString();
                    }
                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr1 = dt.Rows[i];
                        a = Convert.ToInt32(dr1["RcAccCode"].ToString());
                        break;
                    }
                    if (temp == 0)
                    {
                        dr = dt.NewRow();
                        dr[0] = a + 1;
                        dr[1] = TextBox1.Text;
                        dr[2] = TextBox2.Text;
                        dr[3] = TextBox3.Text;
                        dt.Rows.Add(dr);   
                    }
                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] =1;
                    dr[1] = TextBox1.Text;
                    dr[2] = TextBox2.Text;
                    dr[3] = TextBox3.Text;
                    dt.Rows.Add(dr);
                }
            // If ViewState has a data then use the value as the DataSource
            if (ViewState["CurrentData"] != null)
            {
                Gridview1.DataSource = (DataTable)ViewState["CurrentData"];
                Gridview1.DataBind();     
            }
            else
            {
                // Bind GridView with the initial data assocaited in the DataTable
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
            }
            // Store the DataTable in ViewState to retain the values
            ViewState["CurrentData"] = dt;
    }
**Button Click Event**
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["CurrentData"];
        int count = dt.Rows.Count;
        BindGrid(count);
    }
