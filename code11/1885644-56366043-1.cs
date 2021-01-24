    var jsonOutputFormatter = options.OutputFormatters.OfType<JsonOutputFormatter>().FirstOrDefault();
            if (jsonOutputFormatter != null)
            {
                jsonOutputFormatter.SupportedMediaTypes.Add(HttpMediaTypes.Vnd+json.all);
                jsonOutputFormatter.SupportedMediaTypes.Add(HttpMediaTypes.ApplicationOctetStream);
            }
