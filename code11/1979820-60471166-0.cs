     [HttpGet]
            [Authorize]
            public async Task<IActionResult> Contacts()
            {
                var token = await _tokenStore.GetAccessTokenAsync(User.XeroUserId());
    
                var connections = await _xeroClient.GetConnectionsAsync(token);
    
                ContactsViewModel contacts = new ContactsViewModel();
                contacts.Contacts = new List<ContactViewModel>();
    
                if (!connections.Any())
                {
                    return RedirectToAction("NoContacts");
                }   
    
                foreach (var connection in connections)
                {
                    var accessToken = token.AccessToken;
                    var tenantId = connection.TenantId.ToString();
    
    
                    Contacts contactList = await _accountingApi.GetContactsAsync(accessToken, tenantId);
                    contacts.Contacts.AddRange(contactList._Contacts.Select(contact => new ContactViewModel()
                    {
    
                        ContactID = contact.ContactID.ToString(),
                        ContactStatus = contact.ContactStatus.ToString(),
                        Name = contact.Name,
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        IsSupplier = contact.IsSupplier.Value,
                        IsCustomer = contact.IsCustomer.Value
                    }).ToList());
    
                }
                return View(contacts);
    
            }
