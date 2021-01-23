    public class SettingsVerificationFactory : ISettingsVerificationFactory
    {
        public ISettingsVerification Create(Version iisVersion)
        {
            switch (iisVersion)
            {
                case 6:
                    return new Iis6SettingsVerification();
                case 7:
                    return new Iis7SettingsVerification();
                // etc...
            }
        }
    }
