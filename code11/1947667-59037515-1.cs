    var result = (StackObject as IEnumerable)
        .Cast<object>()
        .Select(obj => new { Obj = obj, Prop = obj.GetType().GetProperty(prop)} )
        .FirstOrDefault(item => item.Prop?.GetValue(item.Obj, null)?.ToString() == propVal)
        ?.Prop;
