    public static List<Contacts> SearchContact(string searchText)
    {
            return (from contact in context.tblContacts
                let type = contact.GetType()
                let typesearch = searchText.GetType()
                let properties = type.GetProperties()
                where (from pro in properties
                        where pro.PropertyType == typesearch
                        select pro.GetValue(contact, null)
                        into value
                        select value as string).Any(val => val != null && val == searchText)
                select contact).ToList();
    }
