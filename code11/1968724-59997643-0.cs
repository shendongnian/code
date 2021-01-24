    var rootDialog = new WaterfallDialog("waterfall", new List<WaterfallStep>
    {
        async (stepContext, cancellationToken) => await stepContext.EndDialogAsync()
    });
    var dm = new DialogManager(rootDialog);
    var jss = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.All,
    };
    var json = JsonConvert.SerializeObject(dm, Formatting.Indented, jss);
    Console.WriteLine(json);
    Console.WriteLine(JsonConvert.DeserializeObject<DialogManager>(json, jss));
