    public ActionResult SortDetails(int modelId, String sortBy)
    {
        var model = repository.GetModel(modelId);
        ...
    }
