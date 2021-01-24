        protected override void AttachBaseContext(Context @base)
        {
            Configuration overrideConfiguration = new Configuration();
            overrideConfiguration = @base.Resources.Configuration;
            overrideConfiguration.SetToDefaults();
            Context context = @base.CreateConfigurationContext(overrideConfiguration);
            base.AttachBaseContext(context);
        }
        public override Resources Resources
        {
            get
            {
                Resources res = base.Resources;
                Configuration config = new Configuration();
                config.SetToDefaults();
                res.UpdateConfiguration(config, res.DisplayMetrics);
                return res;
            }
        }
