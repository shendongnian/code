[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit(string name, Category category)
{
    try
    {
        var oldName = name.ToString();
        var newName = category.Name.ToString();
        using (var session = _driver.Session())
        {
            session.WriteTransaction(tx =>
            {
                tx.Run("Match (a:Category) WHERE a.Name = $oldName Set a.Name = $newName", new { oldName, newName });
            });
        }
        return RedirectToAction(nameof(Index));
    }
    catch
    {
        return View();
    }
}
In the parameters section, you just need to supply any object whose property names match the names of the parameters in the query. In your example, the `new { oldName, newName }` section is short-hand for creating an anonymous C# object with two properties, one called `oldName` and one called `newName` whose values are taken from the variables you defined.
You could equivalently have a class represent your parameters:
class MyParams {
   public string oldName { get; set; }
   public string newName { get; set; }
}
var p = new MyParams { oldname = name, newName = category.Name };
tx.Run("Match (a:Category) WHERE a.Name = $oldName Set a.Name = $newName", p);
I prefer the anonymous object approach, your taste may vary.
