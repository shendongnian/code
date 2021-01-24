    public static void Append(Customer customer, string file)
    {
        List<Customer> records = null;
        using (var reader = new StreamReader(file))
        {
            using (var csv = new CsvReader(reader))
            {
                records = csv.GetRecords<Customer>().ToList();
            }
        }
        records.Add(customer);
        using (var writer = new StreamWriter(file))
        {
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(records);
            }
        }
    }
