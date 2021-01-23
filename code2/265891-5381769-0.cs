            public int productId { get; set; }
            public string MUS_K_ISIM { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<MyClass> ChechkBoxDataSource = new List<MyClass>();
                ChechkBoxDataSource.Add(new MyClass() { productId = 1, MUS_K_ISIM = "Stack" });
                ChechkBoxDataSource.Add(new MyClass() { productId = 2, MUS_K_ISIM = "Overflow" });
                ChechkBoxDataSource.Add(new MyClass() { productId = 3, MUS_K_ISIM = "Example" });
                GridView1.DataSource = ChechkBoxDataSource;
                GridView1.DataBind();
            }
        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = (CheckBox)row.FindControl("ProductSelector");
                    if (cb != null && cb.Checked)
                    {
                        int productID = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
                        Response.Write(string.Format("This would have deleted ProductID {0}<br />", productID));
                    }
                }
            }
        }
