            List<Customer> Customers = new List<Customer>() {
                new Customer(){ RecordId = 12, Birthday = new DateTime(1970, 1, 1)},
                new Customer(){ RecordId = 12, Birthday = new DateTime(1982, 3, 22)},
                new Customer(){ RecordId = 12, Birthday = new DateTime(1990, 1, 1)},
                new Customer(){ RecordId = 14, Birthday = new DateTime(1960, 1, 1)},
                new Customer(){ RecordId = 14, Birthday = new DateTime(1990, 5, 15)},
            };
            var groups = Customers.GroupBy(c => c.RecordId);
            IEnumerable<Customer> itemsFromGroupWithMaxDate = groups.Select(g => g.OrderByDescending(c => c.Birthday).First());
            foreach(Customer C in itemsFromGroupWithMaxDate)
                Console.WriteLine(String.Format("{0} {1}", C.RecordId, C.Birthday));
