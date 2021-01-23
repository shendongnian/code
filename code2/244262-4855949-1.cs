    class SettingsSource : IRegistrationSource {
        static readonly MethodInfo BuildMethod = typeof(SettingsSource).GetMethod(
            "BuildRegistration",
            BindingFlags.Static | BindingFlags.NonPublic);
        public IEnumerable<IComponentRegistration> RegistrationsFor(
                Service service,
                Func<Service, IEnumerable<IComponentRegistration>> registrations) {
            var ts= service as TypedService;
            if (ts != null && typeof(ISettings).IsAssignableFrom(ts.ServiceType) {
                var buildMethod = BuildMethod.MakeGenericMethod(ts.ServiceType);
                yield return (IComponentRegistration) buildMethod.Invoke(null, null);
            }
        }
        static IComponentRegistration BuildRegistration<TSettings>()
                where TSettings : ISettings {
            return RegistrationBuilder
                .ForDelegate((c, p) =>
                    c.Resolve<IConfigurationProvider<TSettings>>().Settings)
                .CreateRegistration();
        }
        public bool IsAdapterForIndividualComponents { get { return false; } }
    }
