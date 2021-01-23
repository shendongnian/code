    MethodBase writeLine = typeof(Console).GetMethod(
        "WriteLine", // Name of the method
        BindingFlags.Static | BindingFlags.Public, // We want a public static method
        null,
        new[] { typeof(string), typeof(object[]) }, // WriteLine(string, object[]),
        null
    );
