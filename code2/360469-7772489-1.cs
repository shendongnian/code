    using (var businessManager = new BusinessManager(new DALConnection(this.DalConnectionString)))
    {
           view.DataSource = businessManager.GetData(departmentCode, summaryType, summaryCode, string.Empty);
           RadAjaxPanel2.Controls.Add(view);
    }
