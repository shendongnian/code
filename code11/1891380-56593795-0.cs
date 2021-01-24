    List<string> boxNames = new List<string>();
     for (int i=0;i<Treat_departments.Count;i++)
     {
       boxNames.Add("B" + i.ToString());
     }
    
    foreach( string item in Treat_departments)
     {
      CheckBox itemBox = new CheckBox({ text = item });
     }
