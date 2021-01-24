      public class AppSettings
            {
        
                private static ISettings Settings => CrossSettings.Current;
        
                public static int Age
                {
                    get => Settings.GetValueOrDefault(nameof(Age), 0);
        
                    set => Settings.AddOrUpdateValue(nameof(Age), value);
                }
        
             
        
               
            }
