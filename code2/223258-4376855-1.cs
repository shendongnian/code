    public class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {           
            References(x => x.Owner).Column("yyyy"); // must add .Column if your fieldname is not of Classaname + "_id" form
            
            Id(x => x.ContactId);
    
            Map(x => x.Number);
            Map(x => x.Type);           
        }
    
    }//ContactMap
