    using System.Globalization;
    // ...
    var stringValue = salesTextBox.Text.Replace(',', '.');
    if (double.TryParse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture, out salesAmount))
    {
        // now we can safely parse "3.14" and "3,14" to 3.14
