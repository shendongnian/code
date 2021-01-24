    public class Foo
    {
        public string nameProp { get; set; }
        
        [BindProperty(BinderType = typeof(CustomModelBinder))]
        public string JsonCover { get; set; }
    }
