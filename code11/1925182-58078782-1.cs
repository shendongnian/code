    object variable = null;
    int? Length;
    if(variable != null)
    {
        var a = variable.ToString()?;
        if(a != null)
        {
            var result = a.Trim();
            if(result != null)
                Length = result.Length;
        }
    }
