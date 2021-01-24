public ActionResult Upload()
            {
                return View();
            }
            [HttpPost]
            public async Task<ActionResult> Upload(HttpPostedFileBase file)
            {
                string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string filepath = @"C:\Users\35385\source\repos\BookingSystem\BookingSystem\Surveys\" + filename;
                file.SaveAs(Path.Combine(Server.MapPath("/Surveys"), filename));
                await AzureVisionAPI.ExtractToTextFile(filepath);
                return View();
            }
