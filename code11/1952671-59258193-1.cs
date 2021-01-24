`
private IList<Web_Notes.Models.NotesRequested> DataSetToList(DataSet ds)
    {
        int currentBatch = GetCurrentBatchId();
        var notesList = ds.Tables[0].AsEnumerable().Select(
          (dataRow, index) => new Web_Notes.Models.NotesRequested {
            batch_id = currentBatch,
            rowNumber = index
            note_type = dataRow.Field<string>("Note Type"),
            note_system = dataRow.Field<string>("Note System"),
            note_text = dataRow.Field<string>("Note Text"),
            country = dataRow.Field<string>("Country")
          }
        ).ToList();
        return notesList;
    }
`
