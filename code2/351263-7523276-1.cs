    protected void linqDs_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            object parameter = null;
            if (e.SelectParameters.TryGetValue("employee", out parameter))
            {
                e.Result = DefaultBLL.GetEmployeeTrainingLists(parameter.ToString());
            }
        }
    Hope this help.
