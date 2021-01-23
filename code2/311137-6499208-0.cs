    class MyModel
    {
        public int Id { get;set; }
        public string Title { get;set; }
        public DateTime CreatedDate { get;set; }
        public bool IsActive { get;set; }
    
        public MyModel(int id, string title, DateTime created, bool active)
        {
            Id = id; 
            Title = title;
            CreatedDate = created;
            IsActive = active;
        }
    }
