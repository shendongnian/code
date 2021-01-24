     public ActionResult YourAction(HttpPostedFileBase[] files)
        {
            var data = new Submission()
            {
                ConfigurationDetailId = configDetail.Id,
                SubmitterEmail = submitterEmail,
                SubmissionData = Request.Form.AllKeys.Select(k => new SubmissionData()
                {
                    FieldName = k,
                    FieldValue = Request.Form[k]
                }).ToList(),
                SubmissionFiles = new List<SubmissionFile>()
            };
            if (files.Length > 0)
            {
                foreach (HttpPostedFileBase file in files)
                {
                    var uploadedFile = file;
                    if (!string.IsNullOrEmpty(file.FileName))
                    {
                        data.SubmissionFiles.Add(GetSubmissionFile(uploadedFile, fileName));
                    }
                }
            }
            return View();
        }
