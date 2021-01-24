    public static class AnonymousExt {
        private static readonly CustomAttributeBuilder CompilerGeneratedAttributeBuilder = new CustomAttributeBuilder(typeof(CompilerGeneratedAttribute).GetConstructor(Type.EmptyTypes), new object[0]);
        private static ModuleBuilder AnonTypeMB;
        private static int AssemCount = 25;
    
        // create a pseudo anonymous type (POCO) from an IDictionary of property names and values
        // using public fields instead of properties
        // no methods are defined on the type
        public static Type MakeAnonymousType(IDictionary<string, Type> objDict) {
            // find or create AssemblyBuilder for dynamic assembly
            if (AnonTypeMB == null) {
                var assemblyName = new AssemblyName($"MyDynamicAssembly{AssemCount}");
                var ab = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
                AnonTypeMB = ab.DefineDynamicModule("MyDynamicModule");
            }
            // get a dynamic TypeBuilder
            var typeBuilder = AnonTypeMB.DefineType($"<>f__AnonymousType{AssemCount++}`{objDict.Keys.Count}", TypeAttributes.AnsiClass | TypeAttributes.Class | TypeAttributes.AutoLayout | TypeAttributes.NotPublic | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit);
            typeBuilder.SetCustomAttribute(CompilerGeneratedAttributeBuilder);
    
            // create generic parameters for every field
            string gtpName(string fieldName) => $"<{fieldName}>j__TPar";
            var gtpnames = objDict.Keys.Select(k => gtpName(k)).ToArray();
            var gtpbs = typeBuilder.DefineGenericParameters(gtpnames);
            var gtpN2Bs = gtpnames.Zip(gtpbs, (n, pb) => new { n, pb }).ToDictionary(g => g.n, g => g.pb);
    
            // add public fields to match the source object
            var fbs = new List<FieldBuilder>();
            foreach (var srcFieldName in objDict.Keys)
                fbs.Add(typeBuilder.DefineField(srcFieldName, gtpN2Bs[gtpName(srcFieldName)], FieldAttributes.Public));
    
            // Fix the generic class
            var fieldTypes = objDict.Values.ToArray();        
            return typeBuilder.CreateType().MakeGenericType(fieldTypes);
        }
    
        static string MakeAnonymousTypeKey(IDictionary<string, Type> objDict) => objDict.Select(d => $"{d.Key}~{d.Value}").Join("|");
    
        public static Dictionary<string, Type> PrevAnonTypes = new Dictionary<string, Type>();
        public static Type FindOrMakeAnonymousType(IDictionary<string, Type> objDict) {
            var wantedKey = MakeAnonymousTypeKey(objDict);
            if (!PrevAnonTypes.TryGetValue(wantedKey, out var newType)) {
                newType = MakeAnonymousType(objDict);
                PrevAnonTypes[wantedKey] = newType;
            }
    
            return newType;
        }    
    }
