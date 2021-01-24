    using Google.Cloud.BigQuery.V2;
    using System;
    
    public class BigQueryTableInsertRows
    {
        public void TableInsertRows(
            string projectId = "your-project-id",
            string datasetId = "your_dataset_id",
            string tableId = "your_table_id"
        )
        {
            BigQueryClient client = BigQueryClient.Create(projectId);
            BigQueryInsertRow[] rows = new BigQueryInsertRow[]
            {
                // The insert ID is optional, but can avoid duplicate data
                // when retrying inserts.
                new BigQueryInsertRow(insertId: "row1") {
                    { "name", "Washington" },
                    { "post_abbr", "WA" }
                },
                new BigQueryInsertRow(insertId: "row2") {
                    { "name", "Colorado" },
                    { "post_abbr", "CO" }
                }
            };
            client.InsertRows(datasetId, tableId, rows);
        }
    }
