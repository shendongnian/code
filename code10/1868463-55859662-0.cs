    protected override void AttachBaseContext(Context @base)
        {
            Configuration overrideConfiguration = new Configuration();
            overrideConfiguration = @base.Resources.Configuration;
            overrideConfiguration.SetToDefaults();
            Context context = @base.CreateConfigurationContext(overrideConfiguration);
            base.AttachBaseContext(context);
        }
