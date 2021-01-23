    if(!Page.IsPostBack)
    {
    for (int i = 1; i < 13; i++)
            {
                DropDownList1.Items.Add(new ListItem(i.ToString()));
                DropDownList4.Items.Add(new ListItem(i.ToString()));
            }
            for (int i = 1; i < 32; i++)
            {
                DropDownList2.Items.Add(new ListItem(i.ToString()));
                DropDownList5.Items.Add(new ListItem(i.ToString()));
            }
            for (int i = 2010; i < 2021; i++)
            {
                DropDownList3.Items.Add(new ListItem(i.ToString()));
                DropDownList6.Items.Add(new ListItem(i.ToString()));
            }
            var query = from emp in db.Employees
                        select emp.Employee_Name;
            ListBox1.DataSource = query;
            ListBox1.DataBind();
    }
