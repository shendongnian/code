    var thisType = this.GetType();
    foreach (var prop in baseObj.GetType().GetProperties()
        .Where(p => thisType.GetProperty(p.Name) != null))
    {
        var propGetter = prop.GetGetMethod();
        var propSetter = thisType.GetProperty(prop.Name).GetSetMethod();
        if (propSetter != null)
            propSetter.Invoke(this, new[] { propGetter.Invoke(baseObj, null) });
    }
