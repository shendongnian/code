    var metaData = ModelMetadataProviders
        .Current
        .GetMetadataForProperty(null, typeof(MyViewModel), "EmployeeName");
    if (metaData != null)
    {
        string userRole = metaData.AdditionalValues["role"] as string;
    }
