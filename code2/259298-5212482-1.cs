        public void Page_Load(object sender, EventArgs e)
        {
            Person person = new Person { FirstName = "Hello", LastName = "World" };
            var dictionary = typeof(Person).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(p => p.Name.ToUpperInvariant(), p => (p.GetValue(person, null) ?? string.Empty).ToString());
            var xe = XElement.Parse(File.ReadAllText(HttpContext.Current.Server.MapPath("~/template.htm")));
            foreach (var key in dictionary.Keys)
            {
                foreach (var match in xe.Descendants(key))
                {
                    match.ReplaceAll(dictionary[key]);
                }
            }
        }
