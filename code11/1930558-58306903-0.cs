csharp
    public static bool ValidateConfig(object jsonConfig)
    {
         foreach (string item in jsonConfig) // or something list this...
         {
             if (!Enum.IsDefined(typeof(CustomItem), item))
             {
                  throw new Exception("Enum value does not exist.");
             }
         }
    }
