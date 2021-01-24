 c#
[HttpPost]
    public ActionResult CreateContact(CreateContactStepOne contact)
    {
            if(!ModelState.IsValid)return View(contact);
            person p = new person();
            p.FirstName = contact.FirstName;
            p.LastName = contact.LastName;
            if (contact.PhoneNumber == Phone.Home)
            {
                p.HomePhone = contact.ContactPhoneNumber.ToString();
            }
            else if (contact.PhoneNumber == Phone.Mobile)
            {
                p.MobilePhone = contact.ContactPhoneNumber.ToString();
            }
            else if (contact.PhoneNumber == Phone.Office)
            {
                p.OfficePhone = contact.ContactPhoneNumber.ToString();
            }
            PhonebookEntities db = new PhonebookEntities();
            db.people.Add(p);
            db.SaveChanges();
            //Redirect to ActionMethod ContactDetails and passes the personID as parameter
            return RedirectToAction("AddContactDetails", new { id = p.PersonID });
    }
