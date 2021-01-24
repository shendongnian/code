 int recordsPerPage = 10;
            var list = PIAS.ToList().ToPagedList(page, recordsPerPage);
            if (searchBy == "AssetName")
            {
                var assetnamesearch = list.Where(x => x.AssetName.Contains(search));
                return View(assetnamesearch.ToList().ToPagedList(page, recordsPerPage));
            }
            else
                return View(list);
            }
Thanks for all the responses!
