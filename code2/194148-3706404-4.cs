        [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(ColorConverter)), 
    DebuggerDisplay("{NameAndARGBValue}"), 
    Editor("System.Drawing.Design.ColorEditor, System.Drawing.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public struct Color
        {
        ...
        }
