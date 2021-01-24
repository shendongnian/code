    using UnityEngine;
    
    public class EnumFlagAttribute : PropertyAttribute
    {
        public enum FlagLayout
        {
            Dropdown,
            List
        }
    
        public FlagLayout _layout = FlagLayout.Dropdown;
    
        public EnumFlagAttribute() { }
    
        public EnumFlagAttribute(FlagLayout layout)
        {
            _layout = layout;
        }
    }
