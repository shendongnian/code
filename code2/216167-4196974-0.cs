    string list = "";
    foreach (ReportCriteriaItem item in GetCurrentSelection(...)) {
        if (!string.IsNullOrEmpty(list)) list += ",";
        list += item.???;
    }
    // do something with the list.
