    void BindControl(Control ctl, string valueField, string textField, DataTable data) {
        ctl.DataValueField = valueField;
        ctl.DataTextField = textField ?? valueField; // textField can be null
        ctl.DataSource = data;
        ctl.DataBind();
    }
    
    DBUtil DB = new DBUtil();
    BindControl(ddlTradeGrades, "tradeGrade", "descr", DB.GetExecutionGrades());
    ...
