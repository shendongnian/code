    if (!IsPostBack)
    {
        DDLProgram.DataSource = programEntities;
        DDLProgram.DataTextField = "Shortname";
        DDLProgram.DataValueField = "Id";
        DDLProgram.DataBind();
    }
