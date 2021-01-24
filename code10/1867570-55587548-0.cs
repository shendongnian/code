c#//
        // Summary:
        //     Returns value of specified property as Sandbox.ModAPI.Interfaces.ITerminalProperty.TypeName
        //
        // Parameters:
        //   block:
        //     block reference
        //
        //   propertyId:
        //     property id (name)
        //
        // Type parameters:
        //   T:
        //     required value type of Sandbox.ModAPI.Interfaces.ITerminalProperty.TypeName
        //
        // Returns:
        //     property value as Sandbox.ModAPI.Interfaces.ITerminalProperty.TypeName
        public static T GetValue<T>(this Ingame.IMyTerminalBlock block, string propertyId);
This is how you call it. `item.GetValue<StringBuilder>("gpsCoords")`  
And you can ask another property with different type. `item.GetValue<bool>("IsPerm")`
*The code owner: https://github.com/malware-dev/MDK-SE*
