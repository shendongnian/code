    [Then]
    public void Then_Model_Is_Valid(MyObject myObject)
    {
        // use your binded object here
    }
    [StepArgumentTransformation]
    public MyObject MyObjectTransform(Table table)
    {
        var modelState = new ModelStateDictionary();
        var model = new MyObject();
        var state = TryUpdateModel(model, table.Rows[0].ToDictionary(pair => pair.Key, pair => pair.Value), modelState);
        return model;
    }
