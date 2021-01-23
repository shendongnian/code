    var inputs = new Dictionary<string, object>();
    inputs.Add("title","Mr");
    inputs.Add("name.firstname","Bill");
    inputs.Add("name.lastname","Gates");
    //Execute model binding code
    var inputCustomer = ModelBind<Customer>(inputs);
    //Now you have a customer object correctly populated
    //as if you had done
    var inputCustomer = new Customer(){
        Title : "Mr",
        Name : new Name {
              FirstName : "Bill",
              LastName : "Gates"
        }
    }
       
    //Then using this inputCustomer as the basis for a repository search.
    IList<Customer> matchedCustomers = _custRepo.GetByExample(inputCustomer);
    
