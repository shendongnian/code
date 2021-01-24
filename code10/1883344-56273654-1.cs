    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public class TestController : Controller
        {
        [HttpPost]
        public async Task<JsonResult> UploadFile()
        {
            bool Status = false;
            try
            {
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        var stream = fileContent.InputStream;
                        var fileName = GetFileName();
                        var fileExt = Path.GetExtension(fileContent.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/StaticResource"), fileName + fileExt);
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                            Status = true;
                        }
                    }
                }
            }
            catch {}
            return Json(Status);
        }
    }
