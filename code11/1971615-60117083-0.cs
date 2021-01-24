    IEnumerable<Type> GetFormsAndControlsTypes(Assembly assembly)
    {
        var forms = assembly.GetTypes()
            .Where(type => typeof(Form).IsAssignableFrom(type));
        var controls = forms.SelectMany(
            form => form.GetFields(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(field => typeof(Control).IsAssignableFrom(field.FieldType))
                .Select(field => field.FieldType));
        return forms.Concat(controls).Distinct().ToList();
    }
