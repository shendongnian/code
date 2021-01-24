    string[] students = File.ReadAllLines(filePath);
    
    for (int i = 0; i < students.Length; i++)
    {
        string[] cells = students[i].Split('|');
    
        //Human object...
    
        Human x = new Human();
    
        x.name =cells[0].Trim();
        listbox.add(x);
        failinglistbox.Items.Add(x);
    }
