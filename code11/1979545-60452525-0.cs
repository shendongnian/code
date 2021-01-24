    var settings = new JsonSerializerSettings
    {
        Error = (obj, args) =>
        {
            var contextErrors = args.ErrorContext;
            contextErrors.Handled = true;
        }
    };
    var result = streamReader.ReadToEnd();
    List<ViewModel> viewModel = JsonConvert.DeserializeObject<List<viewModel>>(result, settings);
