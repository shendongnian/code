    public static string UpdateStaticCertificateFormateNo1Data(StaticCertificateFormatNo1LogicLayer StaticFormat1Detail)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        con.Open();
        string strXMLRegistrationDetails, strXMLQutPut = "<root></root>";
        System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(StaticFormat1Detail.GetType());
        System.IO.MemoryStream stream = new System.IO.MemoryStream();
        x.Serialize(stream, StaticFormat1Detail);
        stream.Position = 0;
        XmlDocument xd = new XmlDocument();
        xd.Load(stream);
        strXMLRegistrationDetails = xd.InnerXml;
        SqlTransaction trn = con.BeginTransaction();
        try
        {
            SqlParameter[] paramsToStore = new SqlParameter[2];
            paramsToStore[0] = ControllersHelper.GetSqlParameter("@StaticFormat1Detail", strXMLRegistrationDetails, SqlDbType.VarChar);
            paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.VarChar);
            SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "UPS_UpdateStaticCertificateFormateNo1Detail", paramsToStore);
            trn.Commit();
        }
        catch (Exception ex)
        {
            trn.Rollback();
            con.Close();
            if (ex.Message.Contains("UNIQUE KEY constrastring"))
            { return "Details already in  List"; }
            else { return ex.Message; }
        }
        con.Close();
        return "Details successfully Added...";
    }
