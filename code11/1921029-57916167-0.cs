    public void PopulateMyObject(string ObjectId, object target)
    {
        string ObjectJSON = FetchJsonFromDatabase(ObjectId);
        PopulateObjectFromJson(ObjectJSON, target);
    }
