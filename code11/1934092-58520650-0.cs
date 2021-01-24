    public IActionResult Index(string versionSearch)
        {
            if (versionSearch != null)
            {
                var model = FakeManager.GetAllFake();
                char[] trim = { '.', ' ', '\'' };
                versionSearch = versionSearch.Trim(trim);
                var compare = new Version(versionSearch);
                var result = model.Where(v => Version.Parse(v.Version.Trim(trim)) >= compare);
                return View(result.ToList());
            }
            else
            {
                var model = FakeManager.GetAllFake();
                return View(model.ToList());
            }
        }
