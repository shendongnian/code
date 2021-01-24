    //Create List<T> of type Contact
    IList<Contact> contactInfo = new List<Contact>();
    //Temp var for storing the contact to add to list
    Contact contact = null;
    //Temp var for storing current Intent object
    Intent intent = null;
    
    foreach(DataRow row in yourDataTable.Rows)
    {
             //If we are at a new contact, create the new contact object
             if(contact == null || contact.ID != row["ContactId"].ToString())
             {
                  if(contact != null)
                     contactInfo.Add(contact);
                  //set contact to a new Contact Object with the given contact id
                  contact = new Contact(row["ContactId"].ToString());
             }
                 
             
             //IF we are at a new Intent create it and add to List of Intents of current contact
             if(intent == null || intent.Name != row["Intent"].ToString()
             {
                 intent = new Intent(row["Intent"].ToString());
                 contact.Intents.Add(intent);
             }
 
             contact.Intents[contact.Intents.Count - 1].Add(row["Transcript"].ToString());   
             
             
    }
    
    contactInfo.Add(contact); //Add the final contact to the list
