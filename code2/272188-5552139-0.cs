public ActionResult Edit(string id)
{
  var model = new StringSearchResultsModelIndex();
  model.getData();
  model.SelectedRowId = id;
  return View("SearchGUIString", model);
}
