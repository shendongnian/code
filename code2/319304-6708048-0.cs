    protected string Auth(string uid)
    {
        string xml = String.Empty;
        if (!String.IsNullOrEmpty(Request["uid"]))
        {
            string query1 = "SELECT userid, username, city, state, country, birthday, img1, userLevelName, gendername, title FROM UserInfo INNER JOIN Gend ON UserInfo.gendID = Gend.gendID INNER JOIN UserLevel ON UserInfo.UserLevelID = UserLevel.UserLevelID WHERE userid='" + Request["uid"] + "'";
            System.Data.DataTable dtTable = FillDataTableFromDB(query1);
            string query2 = "SELECT MemID FROM network WHERE userid='" + Request["uid"] + "'";
            System.Data.DataTable memTable = FillDataTableFromDB(query2);            
            xml = "<login result=\"OK\">" +
                "<userData>" +
                    "<id><![CDATA[" + dtTable.Rows[0]["userid"] + "]]></id>" +
                    "<name><![CDATA[" + dtTable.Rows[0]["username"] + "]]></name>" +
                    "<gender><![CDATA[" + dtTable.Rows[0]["gendername"] + "]]></gender>" +
                    "<location><![CDATA[" + dtTable.Rows[0]["city"] + "]]>, <![CDATA[" + dtTable.Rows[0]["state"] + "]]>, <![CDATA[" + dtTable.Rows[0]["country"] + "]]></location>" +
                    "<age>22</age>" +
                    "<photo>http://www.somesite.com/thumbnail.asp?path=" + dtTable.Rows[0]["img1"] + "</photo>" +
                    "<thumbnail>http://www.somesite.com/thumbnail.asp?path=" + dtTable.Rows[0]["img1"] + "</thumbnail>" +
                    "<details><![CDATA[" + dtTable.Rows[0]["title"] + "]]></details>" +
                    "<level><![CDATA[" + dtTable.Rows[0]["userlevelname"] + "]]></level>" +
                    "<profileUrl>http://www.somesite.com/" + dtTable.Rows[0]["username"] + "</profileUrl>" +
                "</userData>";
            if(memTable != null && memTable.Rows.Count >0)
            {
                
                string query3 = "SELECT Distinct userid, username, img1, birthday, gendid, city, state, country, title FROM UserInfo WHERE (userinfo.userid IN (" + memTable.Rows[0]["memid"] + ")) AND userinfo.img1 is not null order by userinfo.username";
                System.Data.DataTable netTable = FillDataTableFromDB(query3);
                if(netTable != null && netTable.Rows.Count >0)
                {
                    xml = "<friends>";
                    foreach(System.Data.DataRow row in netTable.Rows)
                    {
                        xml = "<friend>" +
                            "<id><![CDATA[" + row["userid"] + "]]></id>" +
                            "<name>Bill</name>" +
                            "<gender>0</gender>" +
                            "<location>London, UK</location>" +
                            "<age>22</age>" +
                            "<photo>http://yourdomain/photos/bill.png</photo>" +
                            "<thumbnail>http://yourdomain/photos/bill_small.png</thumbnail>" +
                            "<details>Hello, I am Bill</details>" +
                            "<level>regular</level>" +
                            "</friend>";
                    }
                    xml = "</friends>";
                }
            }
        }
        return xml;
    }
    private System.Data.DataTable FillDataTableFromDB(string query)
    {
        System.Data.DataTable datatable = new System.Data.DataTable(); 
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString))
        {
            using (System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(query, conn))
            {
                adapter.Fill(datatable);
            }
        }
        return datatable;
    }
