    class CVAR
    {
       [ProtectionLevel(CVARFlags.InGameOnly | CVARFlags.Admin)]
       private float gravity = 0.1f;
       [ProtectionLevel(CVARFlags.InGameOnly | CVARFlags.Admin)]
       private float friction = 0.1f;
       [ProtectionLevel(CVARFlags.ReadOnly)]
       private string serverVersion = "x.x.x";
       public void SetCVARValue(string commandLine) {
           string cvarName = GetCvarName(commandLine); // parse the cmd line and get the cvar name from there
           object cvarValue = GetCvarValue(commandLine); // parse the value from the string
           FieldInfo field = typeof(CVAR).GetField(cvarName);
           object[] attributes = field.GetCustomAttributes(typeof(ProtectionLevel), false);
           
           if(attributes.Length > 0) {
               ProtectionLevelAttribute attr = (ProtectionLevelAttribute)attributes[0];
               
               if(attr.CheckConditions(World.Instance)) {
                   field.SetValue(this, cvarValue);
               } else {
                   // error report
               }
           }
       }
    }
