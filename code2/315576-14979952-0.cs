        public string GiveConstuctorArgumentName(Type class, Type constructorArgument)
        {
           var cons = class.GetConstructors();
            
           foreach (var constructorInfo in cons)
           {
              foreach (var consParameter in constructorInfo.GetParameters())
              {
                 if (consParameter.ParameterType == constructorArgument)
                 {
                    return consParameter.Name;
                 }
              }
           }
            
           throw new InstanceNotFoundException();
        }
