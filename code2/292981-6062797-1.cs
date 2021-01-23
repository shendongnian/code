       private void BindMyLists()
        {
            DBUtil DB = new DBUtil();
            BindDropDownList(this.ddlExecutionGrades, DB.GetExecutionGrades(), "executionGrade", "descr");
            BindDropDownList(this.ddlTradeGrades, DB.GetTradeGrades(), "tradeGrade", "descr");
            //etc
        }
        protected void BindDropDownList(DropDownList dropDownList, DataTable dataTable, string dataValueField, string dataTextField)
        {
            dropDownList.DataValueField = dataValueField;
            dropDownList.DataTextField = dataTextField;
            dropDownList.DataSource = dataTable;
            dropDownList.DataBind();
        }
