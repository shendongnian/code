                public void AddPerson(string category, string name)
        {
            // Append person under this header
            var lines = txtMembers.Lines.ToList();
            // First find the line of the category
            var header = txtMembers.Lines.FirstOrDefault(l => l.StartsWith("--" + category));
            // If we don't have this category, add it
            if (header == null)
            {
                lines.Add("--" + category);
                txtMembers.Lines = lines.ToArray();
                header = txtMembers.Lines.FirstOrDefault(l => l.StartsWith("--" + category));
            }
            // Find index of header
            var headerIndex = lines.IndexOf(header);
            lines.Insert(headerIndex + 1, name);
            txtMembers.Lines = lines.ToArray();
        }
