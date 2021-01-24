public ActionResult LoadPage()
{
  var viewModel = service.GetViewModel();
  return View(viewModel);
}
[HttpPost]
public ActionResult PostPage(MyViewModel postedViewModel)
{
  service.UpdateData(postedViewModel);
  // either:
  var freshData = service.GetViewModel();
  return View(freshData);
  // or:
  // this is my preferred method, as it means that pressing F5 will not resubmit the old page
  return RedirectToAction("GetData");
}
// what I mean by integrating the data back into the fresh data:
[HttpPost]
public ActionResult PostWithIntegration(MyViewModel postedData)
{
  var freshData = service.GetViewModel();
  freshData.Update(postedData);
  return View(freshData);
}
