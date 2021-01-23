    if (unusedNewValues.Count > 0)
    {
        bool flag5 = true;
        foreach (string str2 in unusedNewValues)
        {
            object obj5;
            if (acceptedValues.TryGetValue(str2, out obj5))
            {
                builder.Append(flag5 ? '?' : '&');
                flag5 = false;
                builder.Append(Uri.EscapeDataString(str2));
                builder.Append('=');
                builder.Append(Uri.EscapeDataString(
                  Convert.ToString(obj5, CultureInfo.InvariantCulture)));
            }
        }
    }
