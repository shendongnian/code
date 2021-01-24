    void DeleteID_Clicked(object sender, System.EventArgs e)
    {
       var menuItemID = sender as MenuItem;
       var contactID = menuItemID.CommandParameter as ContactID;
          
       for (int i=0;i<_contactsID.Count;i++)
       {
           ContactIDGroup contactIDs = _contactsID[i];
           for (int j = 0; j < contactIDs.Count; j++)
           {
             if (contactIDs[j] == contactID )
              {
                _contactsID[i].RemoveAt(j);
              }
           }
       }
            
    }
