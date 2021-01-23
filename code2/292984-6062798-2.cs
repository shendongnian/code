    void BindControl(DropDownList ddl, string valueField, string textField, DataTable data) {
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField ?? valueField; // textField can be null
        ddl.DataSource = data;
        ddl.DataBind();
    }
    
    DBUtil DB = new DBUtil();
    BindControl(ddlTradeGrades, "tradeGrade", "descr", DB.GetTradeGrades());
    ...
