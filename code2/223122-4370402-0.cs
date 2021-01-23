        [HttpPost]
        public ActionResult test(HttpPostedFileBase file)
        {
            if (file.ContentLength > 400)
            {
                return RedirectToAction("GeneralError", "Error");
            }
            else
            {
                string fileName = Path.GetFileName(file.FileName);
                string uploadPath = Server.MapPath("~/Public/uploads/" + fileName);
                file.SaveAs(uploadPath);
                return View("Index");
            }
        }
