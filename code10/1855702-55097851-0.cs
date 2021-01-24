    public DataTable compareFTPTriggers(string targetConnectionString)
        {
            DataTable oFTPTriggerTableDiffs = new DataTable("oFTPTriggerDiffs");
            oFTPTriggerTableDiffs.Columns.Add("oFTPTriggerID");
            oFTPTriggerTableDiffs.Columns.Add("oFTPTriggerName");
            oFTPTriggerTableDiffs.Columns.Add("Comments");
            try
            {
                deFTPTrigger oSrcFTPTrigger = new deFTPTrigger(m_connectString, m_externalUserID);
                DataTable oSrcFTPTrigList = oSrcFTPTrigger.getAllFTPTriggers();
                string systemUserID = clsSettings.systemUserID(targetConnectionString);
                deFTPTrigger oTrgFTPTrigger = new deFTPTrigger(targetConnectionString, systemUserID);
                DataTable oTrgFTPTrigList = oTrgFTPTrigger.getAllFTPTriggers();
                foreach (DataRow oSrcRow in oSrcFTPTrigList.Rows)
                {
                    string ftpPath = Uri.EscapeUriString(oSrcRow["ftpPath"].ToString());
                    DataRow[] oFilteredRows = oTrgFTPTrigList.Select($"ftpPath= '{ftpPath}' and ftpUserName='{oSrcRow["ftpUserName"]}'");
                    string sKey = $"{oSrcRow["ftpPath"]} - {oSrcRow["ftpUserName"]}";
                    if (oFilteredRows.Length == 0)
                    {
                        oFTPTriggerTableDiffs.Rows.Add(oSrcRow["ftpTriggerID"], sKey, "Addition");
                    }
                    else
                    {
                        if (
                            oSrcRow["ftpPassword"].ToString() != oFilteredRows[0]["ftpPassword"].ToString() ||
                            oSrcRow["waitTime"].ToString() != oFilteredRows[0]["waitTime"].ToString() || oSrcRow["waitType"].ToString() != oFilteredRows[0]["waitType"].ToString() ||
                            oSrcRow["definitionID"].ToString() != oFilteredRows[0]["definitionID"].ToString() || oSrcRow["variableName"].ToString() != oFilteredRows[0]["variableName"].ToString() ||
                            oSrcRow["enabled"].ToString() != oFilteredRows[0]["enabled"].ToString() || oSrcRow["globalName"].ToString() != oFilteredRows[0]["globalName"].ToString()
                           )
                        {
                            oFTPTriggerTableDiffs.Rows.Add(oSrcRow["ftpTriggerID"], sKey, "Properties are different");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               // m_oErrorProvider.writeError(ex.Message);
            }
            DataView dvSorted = oFTPTriggerTableDiffs.DefaultView;
            dvSorted.Sort = "oFTPTriggerName ASC";
            oFTPTriggerTableDiffs = dvSorted.ToTable();
            return (oFTPTriggerTableDiffs);
        }
