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
            var index = new Dictionary<string, Group>(
                groups.SelectMany(group =>
                    group.Select(item => new KeyValuePair<string, Group>(item, group) )
                )
            );
            // This will be a very fast operation
            var whichGroup = index["test@yahoo.com"].Name; // = "Group 1"
        }
