     public static bool EnumTryParse<E>(string enumVal, out E resOut) 
            where E : struct
     {
          var enumValFxd = enumVal.Replace(' ', '_');
          if (Enum.IsDefined(typeof(E), enumValFxd))
          {
              resOut = (E)Enum.Parse(typeof(E), 
                 enumValFxd, true);
              return true;
          }
          // ----------------------------------------
          foreach (var value in
              Enum.GetNames(typeof (E)).Where(value => 
                  value.Equals(enumValFxd, 
                  StringComparison.OrdinalIgnoreCase)))
          {
              resOut = (E)Enum.Parse(typeof(E), value);
              return true;
          }
          resOut = default(E);
          return false;
     }
