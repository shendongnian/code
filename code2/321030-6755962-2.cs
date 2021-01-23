    public static void Main()
    {
        var config = Db4oEmbedded.NewConfiguration();
        // code to create and add employees goes here.
        // access employees that have Smith as the last name
        using (var db = Db4oEmbedded.OpenFile(config, "database.db4o"))
        {
            foreach (var e in EmployeeFactory.GetEmployeesNamedSmith(db))
            {
                Console.WriteLine(e.FirstName + " " + e.LastName);
            }
        }
    }
