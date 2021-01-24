    [HttpGet("{id}", Name = "GetContact")]
    public IActionResult GetById(string id)
    {
        var contact = contactRepository.Get(id);
        if (contact == null)
        {
            return NotFound();
        }
        return new ObjectResult(contact);
    }
