                StringBuilder query = new StringBuilder();
                StringBuilder insertParams = new StringBuilder();
                query.Append(" INSERT INTO ");
                query.Append(source);
                query.Append("(");
                for (int i = 0; i < column.Length; i++)
                {
                    if (i < values.Length - 1)
                    {
                        query.Append(",");
                        insertParams.Append(",");
                    }
                    query.Append(column[i]);
                    insertParams.Append("@" + values[i].ToString());
                }
                query.Append(")");
                query.Append(" VALUES ");
                query.Append("(");
                query.Append(insertValues.ToString());
                query.Append(")");
