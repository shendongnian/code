    public class MyEnumValueConverter : IValueConverter
    {
        public object Convert(object value, Type type, ...)
        {
            var enumVal = (WhatIWantIsA)value;
            switch (enumVal)
            {
                case "NiceHouse": return "A nice house";
                case "FastCar": return "A fast car";
                default: return "Unknown Value"; //or throw exception    
            }
        }
        public object ConvertBack(object value, Type type, ...)
        {
            return value; //probably don't need to implement this
        }
    }
