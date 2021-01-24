<tbody>
@{
    for (int i = 0; i < Model.Documents?.Count(); i++)
    {
        @Html.EditorFor(m => m.Documents[i])
    }
}
</tbody>
instead of:
<tbody>
    @Html.EditorFor(m => m.Documents)
</tbody>
In the controller, the action that handles the submitted model should have an additional parameter:
[HttpPost]
public IActionResult AddFolder(Folder model, IFormCollection form)
{
    foreach (var id in form.FirstOrDefault(f => f.Key == "Documents.index").Value)
    {
        var document = new Document
        {
            Name = form[$"Documents[{id}].Name"],
            Path = form[$"Documents[{id}].Path"]
        };
        model.Documents.Add(document);
    }
    if (!ModelState.IsValid) {
        return View(model);
    }
    
    // Persist to db here
    
    // RedirectToAction or whatever after
}
I don't know if there is a better way to implement this.
If no one posts a better solution in a few days, I will accept this as an answer.
