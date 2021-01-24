    var Table2 = new List<myEntity>();
    Table1.Select(s=>s.Text).OrderBy(o=>o).ToList().ForEach(f=>
    {
        //now append the texts to 
        Table2.Add(new tablesTest { Id = (Table2.Count + 1), Text = f });//remove the Id property manupulation or set it to 0 if you are inserting directly in the database and use the context.SaveChanges();(*if entity-framework*) once the insertion is complete.
    }}
