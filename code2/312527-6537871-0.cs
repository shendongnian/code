        public void GetSettings(Action<HubSettings, Exception> callback)
        {
            var dPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Remove(0, 6);
            callback(new HubSettings {DataPath = dPath}, null);
        }
    }
