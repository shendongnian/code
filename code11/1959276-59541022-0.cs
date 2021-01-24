        public JsonResult OnGetGetSetups(string condition, int vehID)
        {
            if (vehID == 0)
                return null;
            return new JsonResult(_context.Setups.Include(d => d.Driver)
                                                 .Include(sd => sd.SetupDetails)
                                                 .Include(c => c.SetupDetails.Condition)
                                                 .Where(a => a.VehicleId == vehID
                                                            && ((condition != "Dirt" && condition != "Carpet") || a.SetupDetails.Condition.Name == condition))
                                                 .ToList());
        } 
