    string key = "Cycle-"+String.Join("|", options);
    if (!html.ViewContext.HttpContext.Items.Contains(key))
         html.ViewContext.HttpContext.Items.Add(key, 0);
    int index = html.ViewContext.HttpContext.Items[key];
    html.ViewContext.HttpContext.Items[key] = (index + 1) % options.Length;
    return options[index];
