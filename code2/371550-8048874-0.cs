    List<string> rolegiven = new List<string>()
        {
             "A","B","C","D","E","F"
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckBoxList1.DataSource = rolegiven;
                CheckBoxList1.DataBind();
    
                CheckBoxList1.Items[0].Selected = true;
                CheckBoxList1.Items[2].Selected = true;
                CheckBoxList1.Items[4].Selected = true;
                //or
                if(rolegiven.Any(item => item.Equals("A")))
                  CheckBoxList1.Items[0].Selected = true;
                if(rolegiven.Any(item => item.Equals("D")))
                  CheckBoxList1.Items[3].Selected = true;
                ...
            }
        }
