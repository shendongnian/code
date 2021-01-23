            using (ISession sess = SomeCodeToGetASessionNotShownHere())
            {
                List<string> schemas = new List<string>();
                schemas.Add("MySchema");
                // SchemaExport won't create the database schemas for us
                foreach (string schema in schemas)
                {
                    string sql = string.Format(System.Globalization.CultureInfo.InvariantCulture, "if not exists(select 1 from information_schema.schemata where schema_name='{0}') BEGIN     EXEC ('CREATE SCHEMA {0} AUTHORIZATION dbo;') END", schema);
                    sess.CreateSQLQuery(sql).ExecuteUpdate();
                }
            }
