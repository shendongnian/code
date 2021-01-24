        public static OptionSet SimplifiedParsing(Workspace space)
        {
            OptionSet optionsSet = space.Options;
            //reading .editorconfig
            var editorConfigDictionary = File.ReadAllLines(@".editorconfig")
                //here I take only the ones for csharp
                .Where(x => x.StartsWith("csharp"))
                .Select(x =>  x.Split(" = "))
                .ToDictionary(x => x[0], y => y[1]);
            var commonOptionsType = typeof(FormattingOptions);
            var csharpOptionsType = typeof(CSharpFormattingOptions);
            var formattingTypes = new[] {commonOptionsType, csharpOptionsType};
            var optionType = typeof(IOption);
            //here we are filtering all the methods from formattingTypes classes, with reflection, which parse the options by keys which are in editor config
            var allParsingMethods = formattingTypes
                .SelectMany(t => t.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.GetProperty))
                .Where(p => optionType.IsAssignableFrom(p.PropertyType))
                .Select(p => (IOption) p.GetValue(null))
                .Select(GetParsingMethod)
                .Where(ows => ows.Item2 != null)
                .ToImmutableArray();
            foreach ((IOption, OptionStorageLocation, MethodInfo) parsingMethod in allParsingMethods)
            {
                //taking info for invoking TryGetOption
                var (option, editorConfigStorage, tryGetOptionMethod) = parsingMethod;
                object result = null;
                //arguments for reflection invocation
                var args = new[] {editorConfigDictionary, option.Type, result};
                //editorConfigStorage instance on which to call the method
                //invoking bool TryGetOption(IReadOnlyDictionary<string, string> rawOptions, Type type, out object result)
                var isOptionPresent = (bool) tryGetOptionMethod.Invoke(editorConfigStorage, args);
                result = args[2];
                if (isOptionPresent)
                {
                    var optionKey = new OptionKey(option, option.IsPerLanguage ? LanguageNames.CSharp : null);
                    //if option is parsed -> its present and we can add it to OptionSet
                    optionsSet = optionsSet.WithChangedOption(optionKey, result);
                }
            }
            return optionsSet;
            
            //helpers
            (IOption, OptionStorageLocation, MethodInfo) GetParsingMethod(IOption option)
            {
                var editorConfigStorage = option.StorageLocations.IsDefaultOrEmpty
                    ? null
                    : option.StorageLocations.FirstOrDefault(IsEditorConfigStorage);
                //getting TryGetOption method of EditorConfigStorageLocation<T> 
                // original method signature:
                // public bool TryGetOption(IReadOnlyDictionary<string, string> rawOptions, Type type, out object result)
                var tryGetOptionMethod = editorConfigStorage?.GetType().GetMethod("TryGetOption");
                return (option, editorConfigStorage, tryGetOptionMethod);
            }
            bool IsEditorConfigStorage(OptionStorageLocation storageLocation)
            {
                return storageLocation.GetType().FullName
                    .StartsWith("Microsoft.CodeAnalysis.Options.EditorConfigStorageLocation");
            }
        }
