    class DocumentRow {
        public int DocumentId {get;set;}
        public bool Rilevante {get;set;}
        public int TopicId {get;set;}
    }
    ...
    List<DocumentRow> allData;
    ...
    allData = rawTopics.SelectMany(t => t.Documents)
        .Select(d => new DocumentRow
            {
               DocumentId = d.Id,
               Rilevante = d.IsRelevant,
               TopicId = d.Topic.Id // foreign key
            }).ToList();
    ...
    rawDocumentsDataGridView.DataSource = allData
       .Where(d => d.TopicId == tid).ToList();
