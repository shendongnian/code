    [HttpPost]
    public IActionResult Create([FromBody] Contact contact)
    {
        if (contact == null)
        {
            return BadRequest();
        }
        contactRepository.Add(contact);
        return CreatedAtRoute("GetContact", new { id = contact.ContactId }, contact);
    }
