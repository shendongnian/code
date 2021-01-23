    var registrations = this.UnityContainer.Registrations;
                if (registrations != null)
                {
                    foreach (var registration in registrations)
                    {
                        if (registration.LifetimeManagerType != null &&
                            registration.LifetimeManagerType ==               typeof(ContainerControlledLifetimeManager) &&
                            registration.MappedToType.FullName.Equals("Main.ViewModelBase"))
                        {
                            var objectType = registration.LifetimeManager.GetValue().GetType();
                            var newInstance = Activator.CreateInstance(objectType, new object[]{this.UnityContainer});
    
                            registration.LifetimeManager.SetValue(newInstance);                           
                        }
                    }
                }
