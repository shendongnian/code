    using System.Collections.Generic;
    class Power { }
    interface IAbilityPower { Power abilityPower { get; set; } }
    class Scepter : IAbilityPower { public Power abilityPower { get; set; } }
    class Aegis : IAbilityPower { public Power abilityPower { get; set; } }
    
    
    class Test
    {
            public static void Main()
            {
                    var abyssalScepter = new Scepter();
                    var aegisOfTheLegion = new Aegis();
                    var itemsList = new List<IAbilityPower>();
    
                    itemsList.Add(abyssalScepter);
                    itemsList.Add(aegisOfTheLegion);
    
                    var power = itemsList[0].abilityPower;
            }
    }
