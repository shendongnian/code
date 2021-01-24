    public class OfficerList
    {
        public List<string> GetOfficerList(SecurityCoreContext _context)
        {
            List<string> OfficerIDs = new List<string>();
            //use the syntax .ToList() to convert object read from db to list to avoid being re-read again
            var SecLog = _context.SecurityLog.ToList();
            var SecLogOfficer = _context.SecurityLogOfficer.ToList();
            var Officer = _context.Officer.ToList();
            int rowID;
            rowID = 0;
            foreach (SecurityLog sl in SecLog)
            {
                int count = SecLogOfficer.Where(slo => slo.SecurityLogID == sl.ID).Count();
                if (count > 0)
                {
                    OfficerIDs.Add("");
                }
                foreach (SecurityLogOfficer slo in SecLogOfficer.Where(slo => slo.SecurityLogID == sl.ID))
                {
                    OfficerIDs[rowID] = OfficerIDs[rowID] + slo.Officer.FirstName + ", ";
                }
                if (count > 0)
                {
                    OfficerIDs[rowID] = OfficerIDs[rowID].Substring(0, OfficerIDs[rowID].Length - 2);
                }
                rowID++;
            } 
            return OfficerIDs;
        }
    }
