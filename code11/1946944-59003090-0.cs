    try
        {
            IEnumerable<Users> result = (from x in _db.Users.FromSqlRaw("Execute ustp_MyProcedure)").AsEnumerable()
                                         select x);
            return result.ToList();
        }
        catch (Exception ex)
        {
            //Never gets here
        }
