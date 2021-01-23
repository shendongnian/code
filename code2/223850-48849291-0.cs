    class DoClassInvoke
    {
        public void InvokeConstructorHaveInterfaceAsParameter()
        {
            var class1Type = typeof(Class1);
            var mainParamConstructor = SummonParameter(class1Type);
            var mainConstructor = class1Type.GetConstructors().FirstOrDefault();
            var mainConstructorDeclare = mainConstructor.Invoke(mainParamConstructor);
            var mainMethod = class1Type.GetMethod("GetString");
            var mainValue = mainMethod.Invoke(mainConstructorDeclare, new object[] { });
        }
        private object[] SummonParameter(Type classTypeData)
        {
            var constructorsOfType = classTypeData.GetConstructors();
            var firstConstructor = constructorsOfType.FirstOrDefault();
            var parametersInConstructor = firstConstructor.GetParameters();
            var result = new List<object>();
            foreach (var param in parametersInConstructor)
            {
                var paramType = param.ParameterType;
                if (paramType.IsInterface)
                {
                    var implClassList = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(s => s.GetTypes())
                       .Where(w => paramType.IsAssignableFrom(w) & !w.IsInterface).ToList();
                    
                    var implClass = implClassList.FirstOrDefault();
                    var parameteDatar = SummonParameter(implClass);
                    var instanceOfImplement = (parameteDatar == null || parameteDatar.Length == 0)
                        ?
                        Activator.CreateInstance(implClass)
                        :
                        Activator.CreateInstance(implClass, parameteDatar);
                    result.Add(instanceOfImplement);
                }
            }
            return result.ToArray();
        }
    }
