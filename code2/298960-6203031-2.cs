    public List<object> GetMaps() {
        Action<Customer1, Customer2> baseMap = (Customer1 c1, Customer2 c2) => {
            c2.FirstName = c1.FirstName;
        };
    var list = new List<object>()
    {
        (Action<SpecialCustomer1, 
                SpecialCustomer2>(new ModifiedClosure(baseMap).Method)),
        // ...
    };
