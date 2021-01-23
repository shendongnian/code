            Scan(y =>
            {
                y.AssemblyContainingType<IRegistar>();
                y.Assembly(Assembly.GetExecutingAssembly().FullName);
                y.With(new RepositoryScanner());
            })
