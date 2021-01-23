    if(!Page.IsPostBack)
    {
         if (EntityObject== null) 
                EntityObject= new EntityObject(); 
 
            FormView.DataSource = new[] { EntityObject }; 
            FormView.DataBind(); 
     }
}
