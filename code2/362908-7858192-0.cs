    bulkCopy.DestinationTableName = this.Adapter.TableMappings[0].DataSetTable;
    for (int i = 0; i < this.Adapter.TableMappings[0].ColumnMappings.Count; i++)
        bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(
                    this.Adapter.TableMappings[0].ColumnMappings[i].SourceColumn.ToString(),
                    this.Adapter.TableMappings[0].ColumnMappings[i].DataSetColumn.ToString()));
    bulkCopy.BatchSize = BatchSize;
    bulkCopy.WriteToServer(InsertTable);
