    string key = "Cycle-"+String.Join("|", options);
    if (!html.ViewContext.HttpContext.Items.ContainsKey(key))
         html.ViewContext.HttpContext.Items.Add(key, 0);
    int index = html.ViewContext.HttpContext.Items[key];
    html.ViewContext.HttpContext.Items[key] = (options.Length + 1) % options.Length;
    return options[index];
