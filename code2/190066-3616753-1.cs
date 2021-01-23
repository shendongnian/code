    using System.Globalization;
    ...
    NumberFormatInfo nfi = new NumberFormatInfo();
    nfi.NumberDecimalSeparator = ",";
    double num = Convert.ToDouble(test, (IFormatProvider)nfi);
