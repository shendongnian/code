        public static void AddForms(this IUnityContainer container, Assembly assembly = null)
        {
            if (assembly == null) assembly = Assembly.GetCallingAssembly();
            foreach (var form in assembly.GetTypes().Where(x => typeof(Form).IsAssignableFrom(x)))
            {
                var initForm = form.GetCustomAttribute<InitialFormAttribute>();
                if (initForm != null)
                {
                    container.RegisterType(typeof(Form), form, "InitialForm", new TransientLifetimeManager());
                }
                else
                {                    
                    container.RegisterType(form, new TransientLifetimeManager());
                }
            }
        }
