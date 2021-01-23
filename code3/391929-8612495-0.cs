    public class MyRegistrationSource : IRegistrationSource
    {
        /// <summary>
        /// Gets a value indicating whether the registrations provided by this source are 1:1 adapters on top
        /// of other components (I.e. like Meta, Func or Owned.)
        /// </summary>
        public bool IsAdapterForIndividualComponents
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// Retrieve registrations for an unregistered service, to be used
        /// by the container.
        /// </summary>
        /// <param name="service">The service that was requested.</param>
        /// <param name="registrationAccessor">A function that will return existing registrations for a service.</param>
        /// <returns>
        /// Registrations providing the service.
        /// </returns>
        public IEnumerable<IComponentRegistration> RegistrationsFor(
            Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            var swt = service as IServiceWithType;
            if (swt != null)
            {
                // Register requested service types that pass some test or other
                if (swt.ServiceType.HasAttribute<SomeAttribute>(true) ||
                    typeof(SomeType).IsAssignableFrom(swt.ServiceType))
                {
                    var registration = RegistrationBuilder.ForType(swt.ServiceType)
                        .InstancePerDependency()
                        .CreateRegistration();
                    yield return registration;
                }
            }
        }
    }
