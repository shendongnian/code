    class SomeClass
    {
        // These need to be set to appropriate values
        int id, str;
        double dbPercent;
        string constr;
        public bool addWhole()
        {
            var m_flag = false;
            using (var osqlCon = new SqlConnection(constr))
            {
                if (osqlCon.State != ConnectionState.Open)
                {
                    osqlCon.Open();
                }
                using (var osqlTrans = osqlCon.BeginTransaction())
                {
                    try
                    {
                        if (m_flag = this.addRisk(osqlTrans))
                        {
                            if (m_flag = this.addEconomical(osqlTrans))
                            {
                                osqlTrans.Commit();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // Use $exception in watch window if you are debugging
                        osqlTrans.Rollback();
                    }
                }
            }
            return m_flag;
        }
        public bool addRisk(SqlTransaction oRiskTrans)
        {
            var m_flag = false;
            using (var cmd = new SqlCommand("insert into tblEnrollmentData (EID,Eyear,Epercent) values('" + id + "','" + str + "','" + dbPercent + "')"))
            {
                cmd.Transaction = oRiskTrans;
                cmd.Connection = oRiskTrans.Connection;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    m_flag = true;
                }
            }
            return m_flag;
        }
        public bool addEconomical(SqlTransaction oRiskTrans)
        {
            var m_flag = false;
            using (var cmd = new SqlCommand("insert into tblEnrollmentData (EID,Eyear,Epercent) values('" + id + "','" + str + "','" + dbPercent + "')"))
            {
                cmd.Transaction = oRiskTrans;
                cmd.Connection = oRiskTrans.Connection;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    m_flag = true;
                }
            }
            return m_flag;
        }
    }
