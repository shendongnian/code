    public abstract class SettingBase
    {
         public abstract string GetSettingName();
         public abstract SettingBase GetSetting();
         //Shared Properties and Stuff here:
    }
    public class BananaSetting : SettingBase
    {
         public override string GetSettingName()
         {
             return nameof(BananaSetting);
         }
         public override SettingBase GetSetting()
         {
             return this;
         }
         //Banana-Specific Settings go here
    }
    public class DEBUGSetting : SettingBase
    {
         public override string GetSettingName()
         {
             return nameof(DEBUGSetting);
         }
         public override SettingBase GetSetting()
         {
             return this;
         }
         //DEBUG-Specific Settings go here
    }
    public class Program
    {
         public void Demo()
         {
             var settings = LoadSettings();
             foreach(var setting in settings)
             {
                 var implementation = setting.GetSetting();
                 if(implementation is DEBUGSetting dbg)
                 {
                     //access dbg.Properties here
                 }
                 [...]
             }
         }
    }
