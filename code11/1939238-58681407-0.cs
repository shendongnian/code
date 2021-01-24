c#
// Linq is required
// using System.Linq;
// Map your json to a animal queryable;
var animals = json["data"]["animals"].Select(row => new Animal {
       Prop1 = row["prop1"].ToString(),
       Prop2 = row["prop2"].ToString(),
       Prop3 = row["prop3"].ToString()
   });
// Select only unique values
animals = animals.GroupBy(a=>new { a.Prop1, a.Prop2, a.Prop3 }).Select(a => a.First());
// Your logic to insert
foreach (var newRow in animals)
{
    if (!db.Animals.Any(p => p.Prop1 == newRow.Prop1 && p.Prop2 == newRow.Prop2 && p.Prop3 == newRow.Prop3))
    {
        db.Animals.Add(newRow);
        // db.SaveChanges(); // If I put this here instead, it works (no duplicate exception)
    }
}
db.SaveChanges();  // This throws the duplicate exception
