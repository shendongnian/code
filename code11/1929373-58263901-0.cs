    private void FindStudent(string name)
    {
        User std = items.FirstOrDefault(s => s.Name.Contains(name));
        if (std != null)
        {
            this.Title = "Student found!";
        }
        else
        {
            this.Title = "Student NOT found!";
        }
    }
