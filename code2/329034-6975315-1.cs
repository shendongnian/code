    public void UpdateAddress(Address addr)
    {
        using (var context = new MyContext())
        {
            var addressInDb = context.Addresses.Find(addr.Id);
            context.Entry(addressInDb).CurrentValues.SetValues(addr);
            context.SaveChanges();
        }
    }
