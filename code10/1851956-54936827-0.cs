    [HttpPost]
    [ActionName("ExportFolder")]
    [ValidateAntiForgeryToken]
    public JsonResult ExportFolder(int? folderId)
    {
        if (folderId != null)
        {
            using (var ctx = new myContextEntities())
            {
                    var uid = Convert.ToInt32(User.Identity.Name);
                    var itemsToExport = ctx.Items.Where(y => y.MyListId == folderId && y.UserId == uid).ToList();
                    var sw = new StringWriter();
                    sw.WriteLine("\"Title1\",\"Title2 \",\"Title3\",\"Title4\",\"Title5\"");
                    foreach (var item in itemsToExport)
                    {
                        sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"",
                            item.Title1,
                            item.Title2,
                            item.Title3,
                            item.Title4,
                            item.Title5
                            ));
                    }
                    TempData["Contents"] = sw.ToString();
                    return Json("FileName");
            }
        }
        return Json("error");
    }
