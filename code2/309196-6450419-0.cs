           if(!IsPostBack)
           {
                DropDownList.DataSource = dt;                   // dt is the DataTable
                DropDownList.DataTextField = "Name";
                DropDownList.DataValueField = "ID";
                DropDownList.DataBind();               
           }
