    public class LocalVariableNameReader
    {
        Dictionary<int, string> _names = new Dictionary<int, string> ();
    
        public string this [int index]
        {
            get
            {
                if (!_names.ContainsKey (index)) return null;
                return _names [index];
            }
        }
    
        public LocalVariableNameReader (MethodInfo m)
        {
            ISymbolReader symReader = SymUtil.GetSymbolReaderForFile (m.DeclaringType.Assembly.Location, null);
            ISymbolMethod met = symReader.GetMethod (new SymbolToken (m.MetadataToken));
            VisitLocals (met.RootScope);
        }
    
        void VisitLocals (ISymbolScope iSymbolScope)
        {
            foreach (var s in iSymbolScope.GetLocals ()) _names [s.AddressField1] = s.Name;
            foreach (var c in iSymbolScope.GetChildren ()) VisitLocals (c);
        }
    }
