        class Group : List<string>
        {
            public string Name { get; set; }
            public Group(string name) => Name = name;
        }
        static void Main(string[] args)
        {
            var groups = new List<Group> {
                new Group("Group 1") { "email@yahoo.com", "test@yahoo.com" },
                new Group("Group 2") { "myemail@gmail.com", "checkit@gmail.com" }
            };
            var index = groups
                .SelectMany(group => group.Select(item => (item, group)))
                .ToDictionary(x => x.item, x => x.group);
            // This will be a very fast operation
            var whichGroup = index["test@yahoo.com"].Name; // = "Group 1"
        }
