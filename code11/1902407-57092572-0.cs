        var active = (from ap in _context.ApplicationForms
                      join cb in _context.AccessAreaCheckBoxes
                      on ap.RecordId equals cb.RecordId into j1
                      from j2 in j1.DefaultIfEmpty()
                      where ap.EndDate == null
                      && (j2.AccessAreaManagement == null || j2.Checked == true)
                      group new { ap.System, ap.AccessRequiredTo, j2.AccessAreaManagement, ap.EquipmentTag } 
                      by new { System = ap.System.Name, Building = ap.AccessRequiredTo.Name, AccessArea = j2.AccessAreaManagement.Name, Equipment = ap.EquipmentTag.Name } into grp
                      select new RecordViewModel
                      {
                          System = grp.Key.System,
                          AccessRequiredTo = grp.Key.Building,
                          AccessArea = grp.Key.AccessArea,
                          EquipmentTag = grp.Key.Equipment,
                          Count = grp.Count()
                      }).ToList();
