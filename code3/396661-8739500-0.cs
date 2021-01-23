    public List<AXCustomer> allCustomers(string id)
    {
        string[] searchstring = id.Split(' ');
        List<List<AXCustomer>> customerlists = new List<List<AXCustomer>>();
        
        foreach (string word in searchstring)
        {
            customerlists.Add(context.AXCustomers.Where(x => x.ACCOUNTNUM.Contains(word) || x.NAME.Contains(word) || x.ZIPCODE.Contains(word)).ToList());
        }
        //Then you just need to see if you want ANY matches or COMPLETE matches.
        //Throw your results together in a List<AXCustomer> and return it.
       
        return mycombinedlist;
    }
