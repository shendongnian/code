    using System;
    
    [Serializable]
    public class EnumIntArray
    {
        public string[] Names;
        public int[] Values;
    
        public EnumIntArray(Type enumType)
        {
            Names = Enum.GetNames(enumType);
            Values = new int[Names.Length];
        }
    }
