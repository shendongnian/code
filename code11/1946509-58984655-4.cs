    public static void Append2(Customer customer, string file)
    {
        using (var writer = new StreamWriter(file, true))
        {
            writer.WriteLine();
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecord(customer);
            }
        }
    }
