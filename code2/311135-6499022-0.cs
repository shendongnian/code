    class MyModel
    {
        public int Id {get; private set;}
        public string Title {get; private set;}
        public DateTime CreatedDate {get; private set;}
        public bool IsActive {get; private set;}
        Public MyModel(int Id, string Title, DateTime CreatedDate, bool IsActive)
        {
            this.Id = Id; 
            this.Title = Title;
            this.CreatedDate = CreatedDate;
            this.IsActive = IsActive;
        }
    }
