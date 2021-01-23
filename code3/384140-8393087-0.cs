    protected void LinkButton1_Click(Object sender, EventArgs   
     {
             LinkButton button = sender as LinkButton;
              Apartments apartAdmin = new Apartment();
               bool deleted = apartAdmin.Delete(int.Parse(button.CommandArgument.ToString()); 
                if (deleted)
                {
                    radGrid.Rebind();
                }
    
     }
