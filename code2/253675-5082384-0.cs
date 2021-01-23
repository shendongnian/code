    private static bool IsLondon(Customer customer)
    {
        return customer.City == "London";
    }
    ...
    var londoners = customers.Where(IsLondon);
