    ...
    using(profiler.Step("Refresh customer"))
    {
        using(profiler.Step("Query LDAP"))
        { ... }
        using(profiler.Step("Query primary customer DB"))
        { ... }
        using(profiler.Step("Query aux db"))
        { ... }
        using(profiler.Step("Print, scan, and OCR"))
        { ... }
    }
    ...
