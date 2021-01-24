    [HttpPost, ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(tbl_Gallery tbl_Gallery, HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (!ImageUpload.IsImage(file))
                {
                    ModelState.AddModelError("Picture", "Please choose image only");
                }
                else if (file.ContentLength >= 5242880)
                {
                    ModelState.AddModelError("Picture", "Please use a image of size smaller then 5 MB");
                }
                else
                {
                    Random rd = new Random();
                    int rdnum = rd.Next();
                    string path = Server.MapPath("~/Templates/Frontend/img/");
                    string filename = rdnum + file.FileName;
                    string fullpath = Path.Combine(path, filename);
                    file.SaveAs(fullpath);
                    tbl_Gallery.Picture = rdnum + file.FileName;
                }
            }
            try
            {
                if (ModelState.IsValid)
                {
                    db.tbl_Gallery.Add(tbl_Gallery);
                    await db.SaveChangesAsync();
                    return Json(new { success = true });
                }
                else
                {
                    string errorsList = "";
                    foreach (var item in ModelState.Values)
                    {
                        foreach (var err in item.Errors)
                        {
                            errorsList += "<li>" + err.ErrorMessage + "</li>";
                        }
                    }
                    errorsList = "<ul>" + errorsList + "</ul>";
                    return Json(new { success = false, errors = errorsList });
                }
            }
            catch
            {
                return Json(new { success = false, model = View(tbl_Gallery) });
            }
        }
