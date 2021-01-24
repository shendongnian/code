    public List<DoctorDropDoenViewModel> DoctorDropDown()
    {
        var query = (from u in _context.Users
                     join
                     UR in _context.UserRoles on u.Id equals UR.UserId
                     join
                     D in _context.Doctor_Tbl on u.Id equals D.DoctorUserId
                     where UR.PolicyID == 4
                     select new DoctorDropDoenViewModel()
                     {
                         DoctorID = u.Id,
                         DoctorFullName = u.FirstName + " " + u.Family,
                         OrgID = _context.UserChart_Tbl
                         .Where(uc => uc.UserID == u.Id)
                         .Select(g => g.OrgnizationID)  //Select only OrganizationID from complete object
                         .Distinct()   //Remove duplicates.
                         .ToArray()    //Convert IEnumerable<T> to Array
                     });
      return query.ToList();
    }
