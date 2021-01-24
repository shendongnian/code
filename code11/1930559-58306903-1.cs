csharp
    public static bool ValidateConfig(object jsonConfig)
    {
         foreach (string item in jsonConfig) // loop through the config items as string
         {
             if (!Enum.IsDefined(typeof(CustomItem), item))
             {
                  throw new Exception("Enum value does not exist.");
             }
         }
    }
