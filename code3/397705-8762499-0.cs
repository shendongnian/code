    private Dictionary<string, MethodInfo> methodList;
            private List<string> GetMethods(Type type)
            {
                methodList = new Dictionary<string, MethodInfo>();
    
                type.GetMethods().Where(m=>m.IsPublic && m.ReturnType.Equals(typeof(void))).ToList().ForEach(m=>
                    methodList.Add(m.Name,m)
                    );
    
                return methodList.Keys.Select(k => k).ToList();
            }
