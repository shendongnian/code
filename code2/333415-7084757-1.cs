            public class Stats 
            {
                [Display(Name = "Changes", Description = "Changed records.", Order = 8)]
                public int RecordsWithChanges { get; set; }
                [Display(Name = "Invalid", Description = "Number of invalid records analyzed.", Order = 4)]
                public int InvalidRecordCount { get; set; }
                [Display(Name = "Valid", Description = "Number of valid records.", Order = 6)]
                public int ValidRecordCount { get; set; }
                [Display(Name = "Cost", Description = "Number of records with a Cost value.", Order = 10)]
                public int RecordsWithCost { get; set; }
                public Stats(int changed, int valid, int invalid, int cost)
                {
                    RecordsWithChanges = changed;
                    ValidRecordCount = valid;
                    InvalidRecordCount = invalid;
                    RecordsWithCost = cost;
                }
            }
        
            class Program
            {
                static void Main(string[] args)
                {
                    var foo = new Stats(123, 456, 7, 89);
                    var fields = FieldSorter.GetSortedFields(foo.GetType());
                    foreach (DisplayAttribute att in fields.Keys)
                        Console.WriteLine("{0}: {1} ({2}) == {3}", 
                            att.Order, att.Name, att.Description, fields[att].GetValue(foo, null));
    null));
        
                }
            }
