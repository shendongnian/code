    public IList<Contact> GetContacts()
    {
      using(myContext mc = new mc())
      {
        return mc.Contacts.Where(c => c.City = "New York").ToList();
      }
    }
    
    public IList<Sale> GetSales()
    { 
      using(myContext mc = new mc())
      {
        return mc.Sales.Where(c => c.City = "New York").ToList();
      }  
    }
    
    public void SaveContact(Contact contact)
    {
        using (myContext mc = new myContext())
        {
           mc.Attach(contact);
           contact.State = EntityState.Modified;
           mc.SaveChanges();
        }
    }
    
    public void Link()
    {
       var contacts = GetContacts();
       var sales = GetSales();
    
       foreach(var c in contacts)
       {
           c.AddSales(sales.Where(s => s.Seller == c.Name));
           SaveContact(c);
       }
    }
