    [HttpGet]
 	public JsonResult UploadFile()
        {
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);
                    _imgname = Guid.NewGuid().ToString();
                    var _comPath = Server.MapPath("/MyFolder") + _imgname + _ext;
                    _imgname = "img_" + _imgname + _ext;
                    ViewBag.Msg = _comPath;
                    var path = _comPath;
                    tblAssignment assign = new tblAssignment();
                    assign.Uploaded_Path = "/MyFolder" + _imgname + _ext;
                    // Saving Image in Original Mode
                    pic.SaveAs(path);
                }
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        }
