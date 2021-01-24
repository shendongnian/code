     public JsonResult GetStaffResults(DateTime date, string modelId)
            {
                Guid modelGuid = Guid.Parse(modelId);
                var settings = new JsonSerializerSettings();
    
                var staffQuery = context.StaffTable
                    .Where(s => !context
                        .StaffingTable
                        .Any(st => st.StaffId = s.StaffId && st.modelId == modelGuid && st.date == date))
                    .Select(c => new
                    {
                        Id = c.StaffId,
                        Name = c.StaffName
                    });
    
                return Json(staffQuery.ToList(), settings);
            }
