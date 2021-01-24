    services.AddMvc(options => 
    {
        var noContentFormatter = options.OutputFormatters.OfType<HttpNoContentOutputFormatter>().FirstOrDefault();
        if (noContentFormatter != null)
        {
            noContentFormatter.TreatNullValueAsNoContent = false;
        }
    });
