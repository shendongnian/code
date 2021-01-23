    public static Func<Type, DependencyObject, object, Type> LocateTypeForModelType = (modelType, displayLocation, context) => {
        var viewTypeName = modelType.FullName.Substring(
            0,
            modelType.FullName.IndexOf("`") < 0
                ? modelType.FullName.Length
                : modelType.FullName.IndexOf("`")
            );
        Func<string, string> getReplaceString;
        if (context == null) {
            getReplaceString = r => { return r; };
        }
        else {
            getReplaceString = r => {
                return Regex.Replace(r, Regex.IsMatch(r, "Page$") ? "Page$" : "View$", ContextSeparator + context);
            };
        }
        var viewTypeList = NameTransformer.Transform(viewTypeName, getReplaceString);
        var viewType = (from assembly in AssemblySource.Instance
                        from type in assembly.GetExportedTypes()
                        where viewTypeList.Contains(type.FullName)
                        select type).FirstOrDefault();
        return viewType;
    };
