    //assuming you are using linq query
    var allEntry = context.Table.Where(m => m.Category == SelectedCategory);
    var allViews = new List<SampleClass>();
    foreach (var entry in allEntry)
    {
        allViews.Add(new SampleClass
        {
            FieldName = entry.FieldName,
            //and so on...
            
        });
    }
