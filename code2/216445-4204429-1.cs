    public class category_info
    {
        public const string name {get; set};
        public const string description {get; set};
        public int id {get; set;}
        
        public category_info(int id, const string name, const string description){
            this.name = name;
            this.description = description;
            this.id = id;
        }
    }
