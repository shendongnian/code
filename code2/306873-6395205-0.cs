        MasterPageName mp =(MasterPageName) Page.Master;
       //find a control
        Response.Write((mp.FindControl("txtmaster") as TextBox).Text);
       //find a property
       Response.Write(mp.MyProperty.Text);
