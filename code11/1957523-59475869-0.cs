     services.AddMvc(options =>
            {...}).AddJsonOptions(jsonOptions =>
            {
                jsonOptions.SerializerSettings.Converters.Add(new StringEnumConverter());
                jsonOptions.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                jsonOptions.SerializerSettings.NullValueHandling = NullValueHandling.Include;
            })
