            string[] Tags = dr["Tags"].ToString().Split(new char[] { ',' });
            string SqlClause = "";
            for (int i = 0; i < Tags.Length; i++)
            {
                if (i != Tags.Length - 1)
                {
                    SqlClause += "Tags LIKE '%" + Tags[i] + "%' OR ";
                }
                else
                {
                    SqlClause += "Tags LIKE '%" + Tags[i] + "%'";
                }
            }
            DataTable dt = ArticleCollection(SqlClause);
            var seperator = new[] { ",", " " };
            var current = dr["Tags"].ToString();
            var currenttags = dr.Field<string>("Tags").Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            DataTable query = (from row in dt.AsEnumerable()
                        let tags = row.Field<string>("Tags").Split(seperator, StringSplitOptions.RemoveEmptyEntries)
                        let count = tags.Count(t => currenttags.Contains(t))
                        orderby count descending
                        select row).CopyToDataTable();
            for (int i = 0; i < query.Rows.Count; i++)
            {
                if (query.Rows[i]["Title"].ToString() == dr["Title"].ToString())
                {
                    query.Rows[i].Delete();
                }
            }
            TagsRepeater.DataSource = query;
            TagsRepeater.DataBind();
       
        }
    }
    DataTable ArticleCollection(string whereClause)
    {
       
        DataSet ds = TreeHelper.SelectNodes("/%", false, "CriticalCare.Conclusion;CriticalCare.Literature;CriticalCare.Theory", whereClause, " ", -1, true);
        DataTable dt = new DataTable();
        if (!DataHelper.DataSourceIsEmpty(ds))
        {            
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                dt.Merge(ds.Tables[i]);
            }
            return dt;
        }
        return null;
    }
