        //public CheckBox[] Access { get; set; }
        [Required]
        [CustomDisplayName(Name =  new string[] { "First checkbox", "Second checkbox", "Third checkbox" })]
        public bool[] Access1 { get; set; }
        public string[] DisplayName { get; }
        public UsersViewModel()
        {
            DisplayName=GetAttribute(typeof(UsersViewModel)).ToArray();
        }
        private IEnumerable<string> GetAttribute(Type t)
        {
            PropertyInfo props = typeof(UsersViewModel).GetProperties().First(x=>x.Name=="Access1");
            return props.GetCustomAttribute<CustomDisplayName>().Name.ToList();
        }
    }
