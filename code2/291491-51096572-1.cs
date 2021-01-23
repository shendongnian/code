        private void PopulateDropdownList()
        {
            var data= db.HeadSets.ToList()
                        .OrderBy(h => h.Name)
                        .Select(h => new HeadSet
                        {
                            Id = h.Id,
                            Name = h.Name
                        });
            ViewData["headsets"] = headSets;
            int hsID = 0;
            if (headSets.Count() > 0)
            {
                hsID = headSets.First().Id;
            }
            ViewData["defaultHeadSetId"] = hsID;
        }
