    switch (e.Key)
    ...
    case Key.System:
        if (e.SystemKey == Key.F10)
        {
            e.Handled = true;
            ... processing
        }
