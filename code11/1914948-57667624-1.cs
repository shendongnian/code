    private static DataTable GetDataTable()
    {
        DataTable dataTable = new DataTable("tbl");
    
        dataTable.Columns.Add(new DataColumn("mf1"));
        dataTable.Columns.Add(new DataColumn("mf2"));
        dataTable.Columns.Add(new DataColumn("mf3"));
    
        DataRow dataRow;
        for (int i = 0; i < 5; i++)
        {
            dataRow = dataTable.NewRow();
            dataRow[0] = "Some Text " + i;
            dataRow[1] = "Some Bookmaked Text " + i;
            dataRow[2] = "Again Some Text " + i;
            dataTable.Rows.Add(dataRow);
        }
    
        return dataTable;
    }
    
    public class HandleMergeField : IFieldMergingCallback
    {
        void IFieldMergingCallback.FieldMerging(FieldMergingArgs e)
        {
            if (e.FieldName.Equals("mf2"))
            {
                DocumentBuilder builder = new DocumentBuilder(e.Document);
                builder.MoveToMergeField(e.FieldName);
                builder.Font.Color = Color.Red;
    
                builder.StartBookmark("bm_" + e.RecordIndex);
                builder.Write(e.FieldValue.ToString());
                builder.EndBookmark("bm_" + e.RecordIndex);
            }
        }
    
        void IFieldMergingCallback.ImageFieldMerging(ImageFieldMergingArgs args)
        {
            // Do nothing.
        }
    }
