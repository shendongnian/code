    public void Method(Type myType)
    {
        using (var ctx = new FpContext())
        {
            Type myVariableType = myType;
            var table = "myTable";
    
            var sql = ctx.Database
                .SqlQuery(myVariableType, "SELECT * FROM  @table WHERE (UserId = @userid)"
                , new SqlParameter("@userid", user.Id)
                , new SqlParameter("@table", table)).ToList();
        }
    }
