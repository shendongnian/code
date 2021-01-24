    var filteredServices = listOfServices
        .Where(svc =>
                svc.Split().Any(w => tbOneArray.Contains(w, StringComparer.OrdinalIgnoreCase)) &&
                !svc.Split().Any(w => tbTwoArray.Contains(w, StringComparer.OrdinalIgnoreCase)));
    foreach (string service in filteredServices) {
    }
