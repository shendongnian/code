    public static void LoadControllers(this IServiceCollection services)
            {
                // Find controllers in application
                var controllers =
                    from a in AppDomain.CurrentDomain.GetAssemblies()
                    from t in a.GetTypes()
                    let attributes = t.GetCustomAttributes(typeof(ControllerAttribute), true)
                    where attributes?.Length > 0 
                          && !(attributes.Contains(typeof(HttpPostAttribute))
                          || attributes.Contains(typeof(HttpGetAttribute))) // add all attributes of controllers you don't want to change
                    select new {Type = t};
    
                var controllersList = controllers.ToList();
    
                // Change their behaviour and register them
                foreach (var controller in controllersList)
                    services
                        .AddMvc(o => o.Filters.Add(typeof(NonActionAttribute)))
                        .AddJsonOptions(options =>
                            options.SerializerSettings.ContractResolver = new DefaultContractResolver())
                        .AddApplicationPart(controller.Type.Assembly);
            }
