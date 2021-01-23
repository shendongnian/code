    [HttpPost]
    public ActionResult Create(ContactViewModel contactToCreate) {
    
    if (ModelState.IsValid) {
        Contact newContact = new Contact();
        AutoMapper.Mapper.Map(contactToCreate, newContact);
        contactRepository.CreateContact(contactToCreate.GroupId, newContact);   
     }
    }
