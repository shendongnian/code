            Region optAll = new Region { RegionName = "All", RegionId = 0 };
           
            var qOrg = (from rows in LDC.Regions orderby rows.RegionName 
                        select new
                            {
                                rows.RegionId,
                                rows.RegionName
                            }).ToList();
            if(needAll)
                cbo.Items.Add(optAll);
            foreach (var region in qOrg)
            {
                cbo.Items.Add(region);
            }
            cbo.DisplayMember = "RegionName";
            cbo.ValueMember = "RegionId";
