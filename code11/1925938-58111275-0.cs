    public class Group : BindableBase
    {
        string _id;
        public string Id { get => _id; set => SetProperty(ref _id, value); }
        string _name;
        public string Name { get => _name; set => SetProperty(ref _name, value); }
    
        public byte[] GroupPhotoBytes { get; set; } //change similarly like above
        public string CreatedUserId { get; set; } // to do 
        public DateTime CreatedDate { get; set; } // to do
    }
