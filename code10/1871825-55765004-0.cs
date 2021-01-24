        public void AddPerson(string category, string name)
        {
            // First find the line of the category
            var header = txtMembers.Lines.First(l => l.StartsWith("--" + category));
            
            // Append person under this header
            var lines = txtMembers.Lines.ToList();
            // Find index of header
            var headerIndex = lines.IndexOf(header);
            lines.Insert(headerIndex + 1, name);
            txtMembers.Lines = lines.ToArray();
        }
