        public static string GetQueryHtml(string query, List<SqlParameter> parameters = null)
        {
            string _return = ""; string _parmStringValue; string _varlenght = "50";
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter.SqlDbType == SqlDbType.DateTime)
                {
                    _parmStringValue = "'" + ((DateTime)parameter.Value).ToString("yyyy-MM-dd hh:mm:ss") + "'";
                    _return += Environment.NewLine +  "DECLARE " + parameter.ParameterName + " AS " + parameter.SqlDbType.ToString() + " SET " + parameter.ParameterName + " = " + _parmStringValue;
                }                 
                else if (parameter.SqlDbType == SqlDbType.NVarChar || parameter.SqlDbType == SqlDbType.Char)
                {
                    _varlenght = parameter.Value.ToString().Length.ToString();
                    _parmStringValue = "'" + parameter.Value.ToString() + "'";
                    _return += Environment.NewLine + "DECLARE " + parameter.ParameterName + " AS " + parameter.SqlDbType.ToString() + "(" + _varlenght + ") SET " + parameter.ParameterName + " = " + _parmStringValue;
                }
                else
                {
                    _return += Environment.NewLine + "DECLARE " + parameter.ParameterName + " AS " + parameter.SqlDbType.ToString() + " SET " + parameter.ParameterName + " = " + parameter.Value.ToString();
                }
                
            }
            return "<div><pre><code class='language-sql'>" + _return + Environment.NewLine + Environment.NewLine + query + "</code></pre></div>";
        }
~~~~
