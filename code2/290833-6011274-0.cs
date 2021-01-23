    public class MyControl:WebControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public List<MySubItems> Items {get; set;}
    }
