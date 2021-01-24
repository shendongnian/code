typeof(ControllerBase)
.GetProperties()
.Select(x => x.GetCustomAttribute<DisplayAttribute>())
.Where(x => x != null)
.Select(x => x.Name)
.ToList();
**Update:**
Here's a working example:
Assembly.GetExecutingAssembly().GetExportedTypes()
        .Where(t => typeof(ControllerBase).IsAssignableFrom(t))
        .Select(t => t.GetCustomAttribute<DisplayAttribute>())
        .Where(x => x != null)
        .Select(x => x.Name)
        .ToList();
