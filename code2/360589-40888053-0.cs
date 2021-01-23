      private string getGeneratedSql(SqlCommand cmd)
        {
            string result = cmd.CommandText.ToString();
            foreach (SqlParameter p in cmd.Parameters)
            {
                string isQuted = (p.Value is string) ? "'" : "";
                result = result.Replace('@' + p.ParameterName.ToString(), isQuted + p.Value.ToString() + isQuted);
            }
            return result;
        }
