        private void SaveAll(List<MyBO> bos, IDbConnection conn, IDbTransaction trans)
        {
            using (GenericListDataReader<MyBO> reader = new GenericListDataReader<MyBO>((IEnumerable<MyBO>)bos))
            {
                using (SqlBulkCopy bcp = new SqlBulkCopy(
                               (SqlConnection)conn, SqlBulkCopyOptions.CheckConstraints | SqlBulkCopyOptions.FireTriggers,
                               (SqlTransaction)trans))
                {
                    bcp.BulkCopyTimeout = Constants.BULK_COPY_TIMEOUT;
                    bcp.DestinationTableName = "MainAttr";
                    SqlBulkCopyColumnMapping mapID =
                    new SqlBulkCopyColumnMapping("Id", "Id");
                    bcp.ColumnMappings.Add(mapID);
                    SqlBulkCopyColumnMapping mainId =
                        new SqlBulkCopyColumnMapping("Mainid", "MainId");
                    bcp.ColumnMappings.Add(mainId);
                    SqlBulkCopyColumnMapping mapCol =
                        new SqlBulkCopyColumnMapping("Attributecolumn", "AttributeColumn");
                    bcp.ColumnMappings.Add(mapCol);
                    SqlBulkCopyColumnMapping mapVal =
                        new SqlBulkCopyColumnMapping("Attributevalue", "AttributeValue");
                    bcp.ColumnMappings.Add(mapVal);
                    SqlBulkCopyColumnMapping mapLoadDate =
                        new SqlBulkCopyColumnMapping("Loaddate", "LoadDate");
                    bcp.ColumnMappings.Add(mapLoadDate);
                    SqlBulkCopyColumnMapping mapLoadBy =
                        new SqlBulkCopyColumnMapping("Loadby", "LoadBy");
                    bcp.ColumnMappings.Add(mapLoadBy);
                    SqlBulkCopyColumnMapping mapDetail =
                        new SqlBulkCopyColumnMapping("detailid", "DetailId");
                    bcp.ColumnMappings.Add(mapDetail);
                    bcp.NotifyAfter = Constants.BULK_COPY_PROGRESS_REPORT;
                    bcp.SqlRowsCopied += new SqlRowsCopiedEventHandler(bcp_SqlRowsCopied);
                    bcp.WriteToServer(reader);
                }
            }
        }
