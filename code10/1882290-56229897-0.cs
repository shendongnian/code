        var resul = list
            .GroupBy(
                k => k.ID,
                (key, groups) =>
                    groups.Aggregate((accumulatedItem, item) =>
                    {
                        if (accumulatedItem.Status == item.Status)
                        {
                            return string.Compare(accumulatedItem.Rev, item.Rev) >= 0
                                ? accumulatedItem
                                : item;
                        }
        
                        return accumulatedItem.Status == "Active"
                            ? accumulatedItem
                            : item;
                    })
                )
            .ToArray();
        
        var list = new[] {
            new Record("00", "Manual", "000","Active"),
            new Record("00", "Manual", "001","Active"),
            new Record("00", "Manual", "002","Active"),
            new Record("00", "Manual", "003","Active"),
            new Record("00", "Manual", "004","Active"),
            new Record("01", "Manual2", "000", "Active"),
            new Record("01", "Manual2", "001", "Active"),
            new Record("01", "Manual2", "002", "Active"),
            new Record("01", "Manual2", "003", "Active"),
            new Record("01", "Manual2", "004", "Cancel"),
            new Record("02", "Manual3", "000", "Cancel"),
            new Record("02", "Manual3", "001", "Cancel"),
            new Record("02", "Manual3", "002", "Cancel"),
            new Record("02", "Manual3", "003", "Cancel"),
            new Record("02", "Manual3", "004", "Cancel")
            };
        
    public class Record
    {
        public Record(string id, string name, string rev, string status)
        {
            ID = id;
            Name = name;
            Rev = rev;
            Status = status;
        }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Rev { get; set; }
        public string Status { get; set; }
    }
