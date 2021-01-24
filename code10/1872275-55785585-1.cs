    // Example data .....
    DataTable dt = new DataTable();
    dt.Columns.Add("name", typeof(string));
    dt.Columns.Add("surname", typeof(string));
    dt.Columns.Add("phone", typeof(string));
    dt.Rows.Add("charles", "dickens", "11232");
    dt.Rows.Add("mark", "twain", "453446");
    dt.Rows.Add("howard", "lovecraft", "875564");
    dt.Rows.Add("ernst", "hemingway", "1647567");
    dt.Rows.Add("thomas", "mann", "56434");
    dt.Rows.Add("isaac", "asimov", "9700");
    dt.Rows.Add("aldous", "huxley", "2654");
    List<PhoneIndex> phoneIndex = new List<PhoneIndex>();
    
    // Let's enumerate the datatable grouping by first letter in the surname column
    var names = dt.AsEnumerable().GroupBy(d => d.Field<string>("surname").Substring(0, 1))
             // foreach group build a sublist with the info from the datarow 
             // transformed in a PhoneIndexEntry.
             .Select(g => g.Select(p => new PhoneIndexEntry 
             {
                 name = p.Field<string>("name"),
                 surname = p.Field<string>("surname"),
                 telephone = p.Field<string>("phone")
                 
             }));
    // Now we have an IEnumerable<IEnumerable> where the first enumerable is a list 
    // of all distinct first letter from the surname column, while the second
    // is an enumerable of PhoneIndexEntry. 
    // We can loop over the first Enumerable ordering it
    // by the first surname's letter and creating a PhoneIndex with all the PhoneIndexEntry for that specific letter
    foreach (var entry in names.OrderBy(n => n.First().surname[0].ToString()))
        phoneIndex.Add(new PhoneIndex { letter = entry.First().surname[0].ToString(), entries = entry.OrderBy(s => s.surname).ToList()});
        
            
