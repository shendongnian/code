        [HttpPost]
        public ActionResult Index(Models.Project viewModel)
        {
            if (ModelState.IsValid)
            {
                Models.User user = (Models.User)Session["User"];
                Datas.DataSetProjectTableAdapters.tbProjectTableAdapter tbProjectTableAdapter = new Datas.DataSetProjectTableAdapters.tbProjectTableAdapter();
                tbProjectTableAdapter.Insert(
                    viewModel.ProjectTitle
                    , viewModel.ProjectDescriptionShort
                    , viewModel.ProjectDescriptionFull
                    , user.UserId
                    , viewModel.ProjectTypeId
                    );
                Datas.DataSetProject.tbProjectDataTable lastProjectEntry = tbProjectTableAdapter.GetDataByLastInsert();
                int projectId = (int)lastProjectEntry.Rows[0]["Id"];
                string path = Server.MapPath("~/App_Data/UploadedFiles/Project/" + viewModel.ProjectTitle);  // Give the specific path
                if (!(System.IO.Directory.Exists(path)))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                else{}
                foreach (Models.Skill skill in viewModel.Skills)
                {
                    if (skill.IsChecked)
                    {
                        if(skill.files.ContentLength > 0)
                        {
                            ... not implented yet
                        }
                    }
                }
            }
            return View(viewModel);
        }
