    using System;
    using System.ComponentModel;
    using System.Windows.Markup;
    
    namespace zzWpfApp1
    {
        [TypeConverter(typeof(EnumDescriptionTypeConverter))]
        public enum HairColor
        {
            [Description("White")] White,
            [Description("Black")] Black,
            [Description("Brown")] Brown,
            [Description("Red")] Red,
            [Description("Yellow")] Yellow,
        }
    
        public class EnumBindingSourceExtension : MarkupExtension
        {
            private Type _enumType;
    
            public Type EnumType
            {
                get { return this._enumType; }
                set
                {
                    if (value != this._enumType)
                    {
                        if (null != value)
                        {
                            Type enumType = Nullable.GetUnderlyingType(value) ?? value;
    
                            if (!enumType.IsEnum)
                                throw new ArgumentException("Type must be for an Enum.");
                        }
    
                        this._enumType = value;
                    }
                }
            }
    
            public EnumBindingSourceExtension(Type enumType)
            {
                this.EnumType = enumType;
            }
    
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                if (null == this._enumType)
                    throw new InvalidOperationException("The EnumType must be specified.");
    
                Type actualEnumType = Nullable.GetUnderlyingType(this._enumType) ?? this._enumType;
                Array enumValues = Enum.GetValues(actualEnumType);
    
                if (actualEnumType == this._enumType)
                    return enumValues;
    
                Array tempArray = Array.CreateInstance(actualEnumType, enumValues.Length + 1);
                enumValues.CopyTo(tempArray, 1);
                return tempArray;
            }
        }
        class User : INotifyPropertyChanged
        {
            private string _name;
            private HairColor _haircolor;
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
    
            public HairColor HairColor
            {
                get { return _haircolor; }
                set
                {
                    _haircolor = value;
                    NotifyPropertyChanged("HairColor");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
