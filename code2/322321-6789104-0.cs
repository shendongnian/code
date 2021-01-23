    internal class Company
    {
        public string CompanyName { get; set; }
        public string SQLID { get; set; }
        public string column_bar { get; set; }
    }
...
        List<Company> list = new List<Company>();
        list.Add(new Company { CompanyName = "aaaaaa", SQLID = "ssssss", column_bar = "ddddddd" });
        list.Add(new Company { CompanyName = "zzzzzzz", SQLID = "xxxxxx", column_bar = "ccccccccc" });
        cboCompany.DataSource = list;
        cboCompany.DataBind();
        // ...
        string foo = ((List<Company>)cboCompany.DataSource).ElementAt(cboCompany.SelectedIndex).column_bar;
