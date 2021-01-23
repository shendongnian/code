    public DataTable ReadXML(string yourPath)
            {
                DataTable table = new DataTable("Item");
                try
                {
                    DataSet lstNode = new DataSet();
                    lstNode.ReadXml(yourPath);
                    table = lstNode.Tables["Item"];
                    return table;
                }
                catch (Exception ex)
                {
                    return table;
                }
            }
