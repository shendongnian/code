    public static T Log<T>(this T thing) {
        ...
        return thing;
    }
    var result = someObj.ExtensionMethod1().Log()
                        .ExtensionMethod2().Log()
                        .ExtensionMethod3().Log();
