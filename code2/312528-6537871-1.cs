    [PartCreationPolicy(CreationPolicy.Shared)]
        [Export (typeof(IUserServices ))]
        public class TestUserServices:IUserServices 
        {
            public void GetSettings(Action<HubSettings, Exception> callback)
            {
                var dPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Remove(0, 6);
                callback(new HubSettings {DataPath = dPath}, null);
            }
        }
