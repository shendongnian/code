    var added = new List<Animal>();
    foreach (var row in json["data"]["animals"])
    {
        var newRow = new Animal
        {
            Prop1 = row["prop1"].ToString(),
            Prop2 = row["prop2"].ToString(),
            Prop3 = row["prop3"].ToString(),
        }
    
        if (db.Animals.Where(p => p.Prop1 == newRow.Prop1 && p.Prop2 == newRow.Prop2 && p.Prop3 == newRow.Prop3).FirstOrDefault() != null)
        {
            continue;
        }
        if (added.Where(p => p.Prop1 == newRow.Prop1 && p.Prop2 == newRow.Prop2 && p.Prop3 == newRow.Prop3).FirstOrDefault() != null)
        {
            continue;
        }
        added.Add(newRow);
        db.Animals.Add(newRow);
    }
    
    db.SaveChanges();
