    public static String json_encode(IDataReader reader, String[] columns)
        {
            int length = columns.Length;
            String res = "{";
            while (reader.Read())
            {
                res += "{";
                for (int i = 0; i < length; i++)
                {
                    res += "\"" + columns[i] + "\":\"" + reader[columns[i]].ToString() + "\"";
                    if (i < length - 1)
                        res += ",";
                }
                res += "}";
            }
            res += "}";
            return res;
        }
