            var entityAssembly = typeof(BaseEntity).Assembly;
            var modelAssembly = typeof(BaseModel).Assembly;
            var modelNamespace = modelAssembly.GetTypes().Where(a => a.BaseType == typeof(BaseModel)).FirstOrDefault().Namespace;
            foreach (var entity in entityAssembly.GetTypes().Where(a=> a.BaseType == typeof(BaseEntity)))
            {
                var model = modelAssembly.GetType(String.Format("{0}.{1}{2}", modelNamespace, entity.Name, "Model"));
                if (model != null)
                {
                    Mapper.CreateMap(entity, model);
                    Mapper.CreateMap(model, entity);
                }
            }
