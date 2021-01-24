public override Resources Resources
{
  get
  {              
   Configuration config = new Configuration();
   config.SetToDefaults();
               
   Context context = CreateConfigurationContext(config);
   Resources resources = context.Resources;
   return resources;
  }
}
Check https://stackoverflow.com/questions/40221711/android-context-getresources-updateconfiguration-deprecated
#Update 
If you want change the font size , you should override the method `AttachBaseContext`
protected override void AttachBaseContext(Context @base)
{
  // base.AttachBaseContext(@base);
  Configuration config = new Configuration();
  config.SetToDefaults();
  config.FontScale = 1.0f;
  Context context = @base.CreateConfigurationContext(config);
  base.AttachBaseContext(context);
}
