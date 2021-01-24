    public void Create(object obj)
    {
        _doc doc = (_doc)obj;
        string idAsString = doc.DataRecordId.ToString() + doc.Timestamp.ToString();
        int hashId = idAsString.GetHashCode();
        doc.Id = hashId;
        ElasticClient.IndexDocumentAsync(doc);
    }
