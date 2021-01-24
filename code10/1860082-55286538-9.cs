        public ActionResult Edit()
        {
            var fullpath = Path.Combine(Server.MapPath("~/sourcefiles"), "paygroup.txt");
            List<string> paygroupsList = new List<string>();
            List<string> DateList = new List<string>();
            string line;
            using (var sr = new StreamReader(fullpath))
            {
                List<UploadFiles> lst = new List<UploadFiles>()
                while ((line = sr.ReadLine()) != null)
                {
                    string[] strArray = line.Split('|');
                    UploadFiles model = new UploadFiles()
                    {
                       Paygroups = strArray[0],
                       DateAdded = strArray[1]
                    };
                    lst.Add(model);
                }
                Groups group = new Groups();
                group.files = lst;
                return View(group);
            }
        }
