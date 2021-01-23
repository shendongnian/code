    public membershipChkLst(DataTable dt)
    {
       chklst  = new CheckBoxList();
       chklst.ID = "chklstid";
       chklst.DataSource = dt;
       chklst.DataBind();
    }
