    public class Something
    {
        public string Email { get; set; }
        public string Info { get; set; }
    }
    var list = new List<Something>();
    list.Add(new Something { Email = "email1", Info = "info1" });
    list.Add(new Something { Email = "email2", Info = "info2" });
    list.Add(new Something { Email = "email3", Info = "info3" });
    list.Add(new Something { Email = "email4", Info = "info3" });
    list.Add(new Something { Email = "email5", Info = "info3" });
    list.Add(new Something { Email = "email6", Info = "info1" });
    var groupedList = list.GroupBy(e => e.Info).Select(g => new { Info = g.Key, Emails = String.Join(",",g.Select(e => e.Email)) });
