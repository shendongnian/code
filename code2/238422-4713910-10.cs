    public DataResult GetData()
    {
       DataResult result = new DataResult();
       result.AggregatedLabels = new ObservableCollection<AggregatedLabel>();
       result.ContactLists = new ObservableCollection<ContactList>();
    
       // Manipulate data result with your method logic like in this examle:
       foreach(var something in dbResult)
       {
           ContactList cl = new ContactList() { 
           //Binding from something
           }
           result.ContactLists.Add(cl);
       }
       return result; //return your Object Model with required Data!
    }
