    public IDocumentService<TDto> GetDocumentService<TDto>()
            {
                var genericParameter = typeof(TDto);
    
                return (from type in Assembly.GetExecutingAssembly().GetTypes()     // Get Types
                        where type.GetConstructor(Type.EmptyTypes) != null          // That is concrete
                        let interfaces = type.GetInterfaces()                       
                            from intf in interfaces
                        where intf.IsGenericType                                    // Which implement generic interface
                            let genarg = intf.GetGenericArguments()[0] 
                                where genarg == genericParameter                    // Where generic argument is of type genericParameter
                                select (IDocumentService<TDto>)                     // Cast to IDocumentService
                                Activator.CreateInstance(type)).FirstOrDefault();   // Instantiate
            }
