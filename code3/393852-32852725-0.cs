      using (var Scope = Runtime.Container.BeginLifetimeScope("YourScopeTag"))
            {
                var Input = Scope.Resolve<T>();
                action(Input);
            }
