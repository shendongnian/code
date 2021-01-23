    [Microsoft.SqlServer.Server.SqlFunction(IsDeterministic = true)]
    public static SqlString sqlsig(SqlString querystring)
    {
        return (SqlString)Regex.Replace(
           querystring.Value,
           @"([\s,(=<>!](?![^\]]+[\]]))(?:(?:(?:(?:(?# expression coming
           )(?:([N])?(')(?:[^']'')*('))(?# character
           )(?:0x[\da-fA-F]*)(?# binary
           )(?:[-+]?(?:(?:[\d]*\.[\d]*[\d]+)(?# precise number
           )(?:[eE]?[\d]*)))(?# imprecise number
           )(?:[~]?[-+]?(?:[\d]+))(?# integer
           )(?:[nN][uU][lL][lL])(?# null
           ))(?:[\s]?[\+\-\*\/\%\&\\^][\s]?)?)+(?# operators
           )))",
           @"$1$2$3#$4");
    }
