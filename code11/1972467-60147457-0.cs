    public class ContactsController : ApiController
    { 
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return GetContacts();
        }
    
        [HttpPost]
        public HttpResponseMessage Post(Contact contact)
        {            
            SaveContact(contact);
    
            return Request.CreateResponse<Guid>(_code, contact.Id);
        }
    
        [HttpDelete]
        public void Delete(Guid id)
        {
            DeleteContact(id);
        }
    }
