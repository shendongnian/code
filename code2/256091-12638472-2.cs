    public class ComboboxItem
    {
        public object ID { get; set; }
        public string Name { get; set; }
    }
    public static List<ComboboxItem> getReligions()
    {
        try
        {
            List<ComboboxItem> Ilist = new List<ComboboxItem>();
            var query = from c in service.Religions.ToList() select c;
            foreach (var q in query)
            {
                ComboboxItem item = new ComboboxItem();
                item.ID = q.Id;
                item.Name = q.Name;
                Ilist.Add(item);
            }
            ComboboxItem itemSelect = new ComboboxItem();
            itemSelect.ID = "0";
            itemSelect.Name = "<Select Religion>";
            Ilist.Insert(0, itemSelect);
            return Ilist;
        }
        catch (Exception ex)
        {
            return null;
        }    
    }
    ddlcombobox.datasourec = getReligions();
