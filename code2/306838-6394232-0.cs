using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
{
   bulkCopy.DestinationTableName = destinationTableName;
   bulkCopy.WriteToServer(yourDataTable);
}
