    var parameters = NameValueCollection
    {
        { "type_pj[]", "99_AU" },
        { "type_pj[]", "41_NC" },
        { "type_pj[]", "41_NC" }
    }
    var dataPayload = string.Join(
        "&",
        parameters.AllKeys.SelectMany(
            key => parameters.GetValues(key).Select(val => $"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(val)}")
        )
    );
