    string _convertSql( string queryString, List<DatabaseAdapter.Parameter> parameters, 
                        ref List<System.Data.Odbc.OdbcParameter> odbcParameters ) {
        List<ParamSorter> sorter = new List<ParamSorter>();
        foreach (DatabaseAdapter.Parameters item in parameters) {
            string parameterName = item.ParameterName;
            int indexSpace = queryString.IndexOf(paramName + " "); // 0
            int indexComma = queryString.IndexOf(paramName + ","); // 1
            
            if (indexSpace > -1){
                sorter.Add(new ParamSorter() { p = item, index = indexSpace, type = 0 });
            }
            else {
                sorter.Add(new ParamSorter() { p = item, index = indexComma, type = 1 });
            }
        }
        
        odbcParameters = new List<System.Data.Odbc.OdbcParameter>();
        foreach (ParamSorter item in sorter.OrderBy(x => x.index)) {
            if (item.type == 0) { //SPACE
                queryString = queryString.Replace(item.p.ParameterName + " ", "? ");
            }
            else { //COMMA
                queryString = queryString.Replace(item.p.ParameterName + ",", "?,");
            }
            odbcParameters.Add(
                    new System.Data.Odbc.OdbcParameter(item.p.ParameterName, item.p.Value));
        }
    }
