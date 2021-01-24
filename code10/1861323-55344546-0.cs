    protected void Page_Load(object sender, EventArgs e)
    {
      _searchDT = _dtMgr.GetTicketsByKeyword(uxKeywordTextBox.Text, null);
          ....
          if (!Page.IsPostBack)
                {
                    DataRow dr = null;
                    dr = _searchDT.NewRow();
                    _searchDT.Rows.Add();
                    uxSearchGridView.DataSource = _searchDT;
                    uxSearchGridView.DataBind();
                }
            }
         ...
    }
