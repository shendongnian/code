    [XmlType("Widgets"), Serializable]
    public class WidgetList : List<Widget> { }
    [XmlType("Widget"), Serializable]
    public class Widget
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public Widget() { }
    
        public Widget(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
