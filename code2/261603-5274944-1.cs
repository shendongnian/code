     if(actionFilter is ISuperActionFilter){
            var propertiesToInject = 
                GetType()
                .GetProperties(BindingFlags.Public|BindingFlags.Instance)
                .Select(p => new{ 
                    InjectAttribute = p.GetCustomAttributes(typeof(InjectAttribute),true).FirstOrDefault(),
                    PropertyInfo = p}
                    )
                    .Where(x=> x.InjectAttribute != null);
            foreach(var syringe in propertiesToInject)
            {
                syringe.PropertyInfo.SetValue(actionFilter, _serviceProvider.GetService(syringe.PropertyInfo.PropertyType), null);
            }
     }
