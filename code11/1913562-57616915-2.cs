     public virtual DashBoardData GetDashBoardData(short parentSiteId, short siteId, int loggedUserId)
    {
	try
            {
           
                OracleParameter p1 = new OracleParameter("p_ParentSiteId", parentSiteId);
                OracleParameter p2 = new OracleParameter("p_SiteId", siteId);
                OracleParameter p3 = new OracleParameter("p_LoggedUserId", loggedUserId);
                OracleParameter p4 = new OracleParameter("CUR", OracleDbType.RefCursor, ParameterDirection.Output);
                OracleParameter p5 = new OracleParameter("CUR2", OracleDbType.RefCursor, ParameterDirection.Output);
               
                string sql = "BEGIN GET_DEPT_PROC(:p_ParentSiteId, :p_SiteId, :p_LoggedUserId, :CUR2, :CUR);END;";
                var res = context.Set<DashBoardData>().FromSql(sql, p1, p2, p3, p4, p5).ToList();
                return res[0];
            }
            catch (Exception x)
            {
                XLogger.Error("Exception : " + x);
                return null;
            }
      }
