    public bool createContact(CONTACT_ROLES role)
    {
         Contact contact = new Contact();
         String prefix = "";
         string firstName;
         string lastName;
         switch(role)
         {
             case CONTACT_ROLES.ADMIN :
                 firstName = AdminFirstName.Text;
                 lastName= AdminLastName.Text;
                 break;
             case CONTACT_ROLES.OWNER :
                 firstName = OwnerFirstName.Text;
                 lastName= OwnerLastName.Text;
                 break;
             //and so on....
         }
    
    
         
         contact.firstName = firstName ;
         contact.lastName = lastName;
    }
