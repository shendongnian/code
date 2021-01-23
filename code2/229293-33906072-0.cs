    var tryParseMethod = typeof(int).GetMethod(nameof(int.TryParse),
                                                new[] { typeof(string), typeof(int).MakeByRefType() });
    // use it:
    var parameters = new object[] { "1", null };
    var success = tryParseMethod.Invoke(null, parameters);
    var result = (int)parameters[1];
