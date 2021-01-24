    var rawJson = await client.PostAsync(
                    urlParameters,
                    new StringContent(
                        JsonConvert.SerializeObject(parameter).ToString(),
                        Encoding.UTF8,
                        "application/json")
                    ).Content.ReadAsStringAsync();
                    
    var mappedObj = JsonConvert.DeserializeObject<T>(rawJson,
        new JsonSerializerSettings
        {
            Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
            {
                // convert this to your logger
                LogHelper.Instance.Warning(2000, string.Format("Failed object mapping: {0}\n{1}",
                    args.ErrorContext.Error, rawJson));
                args.ErrorContext.Handled = true;
            },
            // set culture to mitigate mapping issues related to dates/numbers
            // https://stackoverflow.com/a/34529198
            Culture = CultureInfo.InvariantCulture
        });
