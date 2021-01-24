    public GraphQLController(
        ISchema schema,
        IDocumentExecuter documentExecuter,
        DataLoaderDocumentListener dataLoaderListener)
    {
        _schema = schema;
        _documentExecuter = documentExecuter;
        _dataLoaderListener = dataLoaderListener;
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]BaseGraphQuery query)
    {
        var inputs = query.Variables.ToInputs();
        var executionOptions = new ExecutionOptions
        {
            Schema = _schema,
            Query = query.Query,
            Inputs = inputs,
        };
        // Important!
        executionOptions.Listeners.Add(_dataLoaderListener);
        // (Execute the query)
    }
