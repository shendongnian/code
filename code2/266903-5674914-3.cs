    ABAddressBook iPhoneAddressBook = new ABAddressBook();
    
    ABPerson[] Contacts = iPhoneAddressBook.GetPeople();
    
    foreach (ABPerson item in Contacts) {
    
    	ABMultiValue<NSDictionary> Contact  = item.GetPhones();
    
    	foreach (ABMultiValueEntry<NSDictionary> cont in Contact) {
                    // cont.Label  indicates the type ( home,work,etc)
    		// get the contact via cont.Value
    
    	} 
    }
