    class MyModel
    {
        private int _id;
        public bool HasId { get; set; }
        public int Id
        {
            get
            {
                if (!HasId) throw new System.InvalidOperationException();
                return _id;
            }
            set
            {
                HasId = true;
                _id = value;
            }
        }
        private string _title;
        public bool HasTitle { get; set; }
        public string Title
        {
            get
            {
                if (!HasTitle) throw new System.InvalidOperationException();
                return _title;
            }
            set
            {
                if (value == null) throw new System.ArgumentNullException("Title");
                HasTitle = true;
                _title = value;
            }
        }
        private DateTime _createdDate;
        public bool HasCreatedDate { get; set; }
        public DateTime CreatedDate
        {
            get
            {
                if (!HasCreatedDate) throw new System.InvalidOperationException();
                return _createdDate;
            }
            set
            {
                HasCreatedDate = true;
                _createdDate = value;
            }
        }
        private bool _isActive;
        public bool HasIsActive { get; set; }
        public bool IsActive
        {
            get
            {
                if (!HasIsActive) throw new System.InvalidOperationException();
                return _isActive;
            }
            set
            {
                HasIsActive = true;
                _isActive = value;
            }
        }
    }
