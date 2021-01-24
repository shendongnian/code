    public ActionResult Contacts(int id)
        {
            var Contacts =
                    from contact in _context.Contacts
                    join assignedcontact in _context.AssignedContacts on contact.Id equals assignedcontact.ContactId
                    where assignedcontact.ReferenceCaseID == id
                    select contact;
            if (Contacts == null)
                return HttpNotFound();
            return View(Contacts);
        }
