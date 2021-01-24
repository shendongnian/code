    public enum WhitelistedTypes
    {
        Head = 1,
        Torso = 2,
        Legs = 3,
    }
    var armorInstance = new Armor();
    var asm = typeof(Armor).Assembly;
    foreach (var item in Enum.GetValues(typeof(WhitelistedTypes)))
    {
        var typeName = ((WhitelistedTypes)item).ToString();                
        var objectType = typeof(Armor).Assembly.CreateInstance("SlotNamespace." + typeName).GetType();
        if(armorInstance.Slot.GetType() == objectType)
        {
            //Do something
        }
    }
