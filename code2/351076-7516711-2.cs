        public bool hasRole(string role, DataTable dtAssignedRoles)
        {
            if (dtAssignedRoles != null && dtAssignedRoles.Rows.Count > 0)
            {
                foreach (DataRow dr in dtAssignedRoles.Rows)
                {
                    if (dr["OT_ROLE"].ToString().ToUpper().Equals(role))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
