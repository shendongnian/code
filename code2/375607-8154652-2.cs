        public DataSet GetInformation(string str)
        {
            ds = new DataSet("Tables");
            Npgsql.NpgsqlDataAdapter da = new Npgsql.NpgsqlDataAdapter(str, connection);
            da.TableMappings.Add("Table", "Program");
            da.Fill(ds);
            return ds;
        }// send query to database, get table
