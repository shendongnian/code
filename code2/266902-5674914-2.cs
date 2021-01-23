	ABMultiValue<NSDictionary> Contact  = item.GetPhones();
	foreach (ABMultiValueEntry<NSDictionary> cont in Contact) {
                // cont.Label  indicates the type ( home,work,etc)
		// get the contact via cont.Value
	} 
}
