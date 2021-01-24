    public PartialViewResult AllStates(string state, string userid)
    {
        // define stored procedure parameter here
        var parameter = new SqlParameter("@userid", SqlDbType.BigInt);
        parameter.Value = userid;
        List<Farmer> model = db.Farmer.Where(u => u.FarmState == state).Take(3).ToList();
        // use stored procedure parameter declared above
        var modelfollow = db.Following.SqlQuery("[dbo].[SelectFollow] @userid", parameter).ToList();
        ViewBag.folo = modelfollow;
        return PartialView("_UsersList", model);
    }
