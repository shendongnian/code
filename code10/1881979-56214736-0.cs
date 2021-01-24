        public IList<string> EntityList()
        {
            IList<string> PropertyList = new List<string>();
            var Properties = typeof(DataContext).GetProperties();
            foreach (var property in Properties)
            {
                PropertyList.Add(property.Name);
            }
            return PropertyList;
        }
