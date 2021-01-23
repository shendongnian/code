    interface IUpgradeCommand<TApp>()
    {
        bool UpgradeApplies(TApp app);
        void ApplyUpgrade(TApp app);
    }
    class UpgradeTo1002 : IUpgradeCommand<App>
    {
        bool UpgradeApplies(App app) { return app.Version < 1002; }
        void ApplyUpgrade(App app) {
            // ...
            app.Version = 1002;
        }
    }
    class App
    {
        public int Version { get; set; }
        IUpgradeCommand<App>[] upgrades = new[] {
            new UpgradeTo1001(),
            new UpgradeTo1002(),
            new UpgradeTo1003(),
        }
        void Upgrade()
        {
            foreach(var u in upgrades)
                if(u.UpgradeApplies(this))
                    u.ApplyUpgrade(this);
        }
    }
