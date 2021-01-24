            var profiles = AllClasses.FromLoadedAssemblies().
                Where(type => typeof(Profile).IsAssignableFrom(type));
            //add profiles to config
            var mapconfig = new MapperConfiguration(cfg =>
            {
                // Magic should happen here
                foreach (var profile in profiles)
                {
                    var resolvedProfile = container.Resolve(profile) as Profile;
                    cfg.AddProfile(resolvedProfile);
                }
            });
            //register mapper using config
            container.RegisterInstance<IMapper>(mapconfig.CreateMapper());
