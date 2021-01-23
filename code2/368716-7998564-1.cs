    public static WebApiConfiguration ModelValidationFor<T>(this WebApiConfiguration conf)
        {
            conf.AddRequestHandlers((coll, ep, desc) => 
                {
                    if (desc.InputParameters.Any(p => p.ParameterType == typeof(T)))
                    { 
                        coll.Add(new ValidationHandler<T>(desc));
                    }
                });
            return conf;
        }
