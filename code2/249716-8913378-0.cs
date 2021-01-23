        Html.DropDownListFor(m => m.ContactId, 
            new SelectList(
                Model.Contacts.Select(
                c => new 
                { 
                    Id = c.ContactId, 
                    FullName = c.FirstName + " " + c.LastName 
                }), 
                "Id", 
                "FullName"))
