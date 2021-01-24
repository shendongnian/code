    public class OfficerList
    {
        public List<string> GetOfficerList(SecurityCoreContext _context, SecurityLog secLog, int rowID, List<string> OfficerIDs)
        {            
            int CurrentID = secLog.ID;
            var SecLogOfficer = _context.SecurityLogOfficer.ToList();
            var Officer = _context.Officer.ToList();
            
            int count = SecLogOfficer.Where(slo => slo.SecurityLogID == CurrentID).Count();
            if (count >= 0)
            {
                OfficerIDs.Add("");
            }
            foreach (secLog slo in SecLogOfficer.Where(slo => slo.SecurityLogID == CurrentID))
            {
                OfficerIDs[rowID] = OfficerIDs[rowID] + slo.Officer.FullName + ", ";
            }
            if (count > 0)
            {
                OfficerIDs[rowID] = OfficerIDs[rowID].Substring(0, OfficerIDs[rowID].Length - 2);
            }
            
            return OfficerIDs;
        }
    }
