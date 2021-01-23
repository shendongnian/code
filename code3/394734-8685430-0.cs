        public int GetTotalNumberOfAprovedPictureIds(string SexType)
        {
            string strConectionString = ConfigurationManager.AppSettings["DataBaseConnection"];
            using (SqlConnection conn = new SqlConnection(strConectionString))
            {
                conn.Open();
                using (SqlCommand oCommand = new SqlCommand("SELECT COUNT(1) FROM MEMBERS INNER JOIN Picture ON MEMBERS.MemberID = Picture.MemberID WHERE (Picture.PicAproval = 1) AND (Picture.PicArchive = 0) AND (MEMBERS.MemberSex = @dSexType)", conn))
                {
                    oCommand.CommandType = CommandType.Text;
                    SqlParameter myParam = oCommand.Parameters.Add("@dSexType", SqlDbType.Text);
                    myParam.Value = SexType;
                    object oValue = oCommand.ExecuteScalar();
                    if (oValue == DBNull.Value)
                    {
                        return 0;
                    }
                    else
                    {
                        return Convert.ToInt32(oValue);
                    }
                }
            }
        }
