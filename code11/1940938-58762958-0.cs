 Func<WorkshopContact, ContactResponse> contactResponseProjection= p => new ContactResponse
 {
   Id = p.Contact.Id,
   Type = p.Contact.ContactType.Description,
   Code = p.Contact.ContactType.Code,
   Value = p.Contact.Value
 };
And use:
...
  Contacts = a.WorkshopContacts.Select(contactResponseProjection).ToList(),
...
