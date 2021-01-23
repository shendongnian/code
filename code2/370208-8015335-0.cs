    public void TestProcWithOutParameter()
    {
        connection.Execute(
            @"CREATE PROCEDURE #TestProcWithOutParameter
    @ID int output,
    @Foo varchar(100),
    @Bar int
    AS
    SET @ID = @Bar + LEN(@Foo)");
        var obj = new
        { // this could be a Person instance etc
            ID = 0,
            Foo = "abc",
            Bar = 4
        };
        var args = new DynamicParameters(obj);
        args.Add("ID", 0, direction: ParameterDirection.Output);
        connection.Execute("#TestProcWithOutParameter", args,
                     commandType: CommandType.StoredProcedure);
        args.Get<int>("ID").IsEqualTo(7);
    }
