    public class ContactService : IContactService {
        ContactDBContext db;
        public ContactService (ContactDBContext db) { 
            this.db = db
        } 
        public async Task<List<ContactModel>> GetContacts() {
            var contacts = db.Contacts;
            //...convert to models
            //...
        }
    }
