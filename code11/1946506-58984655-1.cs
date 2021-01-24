    public static void Update(Customer customer, string file)
    {
        List<Customer> records = null;
        using (var reader = new StreamReader(file))
        {
            using (var csv = new CsvReader(reader))
            {
                records = csv.GetRecords<Customer>().ToList();
            }
        }
        var index = records.FindIndex(x => x.ID == customer.ID);
        if (index >= 0)
        {
            records[index] = customer;
            using (var writer = new StreamWriter(file))
            {
                using (var csv = new CsvWriter(writer))
                {
                    csv.WriteRecords(records);
                }
            }
        }
    }
