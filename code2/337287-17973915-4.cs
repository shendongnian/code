     class Mysql
    {
        public static string INSERT(string INTO, NameValueCollection VALUES)
        {
            string queryString = "INSERT INTO " + INTO + " (";
            for (int i = 0; i < VALUES.Count; i++)
            {
                queryString += VALUES.Keys[i] + (i + 1 == VALUES.Count ? "" : ",");
            }
            queryString += ") VALUES (";
            for (int i = 0; i < VALUES.Count; i++)
            {
                queryString += Escape(VALUES[VALUES.Keys[i]]) + (i + 1 == VALUES.Count ? ("") : (","));
            }
            queryString += ");";
            return queryString;
        }
        public static string DELETE(string FROM, NameValueCollection WHERE)
        {
            string queryString = "DELETE FROM " + FROM + " WHERE";
            for (int i = 0; i < WHERE.Count; i++)
            {
                queryString += " " + WHERE.Keys[i] + "=" + Escape(WHERE[WHERE.Keys[i]]);
            }
            queryString += ";";
            return queryString;
        }
        public static string UPDATE(string UPDATE, NameValueCollection SET, NameValueCollection WHERE)
        {
            string queryString = "UPDATE " + UPDATE + " SET";
            for (int i = 0; i < SET.Count; i++)
            {
                queryString += " " + SET.Keys[i] + "=" + data.Escape(SET[SET.Keys[i]]) + (i + 1 == SET.Count ? ("") : (","));
            }
            queryString += " WHERE";
            for (int i = 0; i < WHERE.Count; i++)
            {
                queryString += " " + WHERE.Keys[i] + "=" + data.Escape(WHERE[WHERE.Keys[i]]);
            }
            queryString += ";";
            return queryString;
        }
        public static string SELECT(string[] SELECT, string FROM, NameValueCollection WHERE)
        {
            string queryString = "SELECT ";
            for (int i = 0; i < SELECT.Length; i++)
            {
                queryString += SELECT[i] + (i + 1 == SELECT.Length ? ("") : (","));
            }
            queryString += " FROM " + FROM + " WHERE ";
            for (int i = 0; i < WHERE.Count; i++)
            {
                queryString += " " + WHERE.Keys[i] + "=" + Escape(WHERE[WHERE.Keys[i]]);
            }
            queryString += ";";
            return queryString;
        }
        public static string Escape(string input)
        {
            using (var writer = new StringWriter())
            {
                using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                {
                    provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
                    return writer.ToString();
                }
            }
        }
    }
