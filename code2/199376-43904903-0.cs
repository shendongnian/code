        _ListAllColors = new List<Color>();
        _SystemColorProperties = typeof(SystemColors).GetProperties();
        foreach (PropertyInfo propertyInfo in _SystemColorProperties)
        {
            object colorObject = propertyInfo.GetValue(null, null);
            Color color = (Color)colorObject;
            if (!_ListAllColors.Contains(color))
            {
                systemColorsComboBox.Items.Add(ReduceName(color));
                _ListAllColors.Add(color);
            }
        }
        foreach (KnownColor colorValue in Enum.GetValues(typeof(KnownColor)))
        {
            Color color = Color.FromKnownColor(colorValue);
            if (!_ListAllColors.Contains(color))
            {
                professionalColorsComboBox.Items.Add(ReduceName(color));
                _ListAllColors.Add(color);
            }
        }
