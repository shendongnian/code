    public class MenuItem
    {
        public int MenuID { get; set; }
        public int ID { get; set; }
        public String Label { get; set; }
        public String Link { get; set; }
        public Boolean Show { get; set; }
        public MenuItem(int menuId, int id, string label, string link, Boolean show)
        {
            this.MenuID = menuId;
            this.ID = id;
            this.Label = label;
            this.Link = link;
            this.Show = show;
        }
    }
//
    public class Menu
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public Menu(int id, string name)
        {
            this.ID = id;
            this.Name = name;
            this.MenuItems = new List<MenuItem>();
        }
    }
