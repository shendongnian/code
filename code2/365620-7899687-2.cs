    public static void GetElementValue(XElement xElement, string parameter, out bool value)
        {
            var stringValue = xElement.Element(parameter).Value;
            value = false;
            if (value != null)
                value = Convert.ToBoolean(stringValue);
        }
