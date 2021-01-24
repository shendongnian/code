    public class LocalizationInfo : Dictionary<string, string>
    {
        public LocalizationInfo() : base( StringComparer.InvariantCultureIgnoreCase ) { }
    }
    public class LocalizationItem : Dictionary<string, LocalizationInfo>
    { }
    public class LocalizationCollection : List<LocalizationItem>
    {
        public Dictionary<string, string> GetLocalizedDict( string cultureName )
        {
            if ( cultureName is null )
            {
                throw new ArgumentNullException( nameof( cultureName ) );
            }
            return this
                .Where( e => e.Count == 1 )
                .Select( e => e.First() )
                .ToDictionary( e => e.Key, e => e.Value == null ? e.Key : e.Value.TryGetValue( cultureName, out var localizedValue ) ? localizedValue : e.Key );
        }
        public Dictionary<string, string> GetLocalizedDict( CultureInfo cultureInfo )
        {
            if ( cultureInfo is null )
            {
                throw new ArgumentNullException( nameof( cultureInfo ) );
            }
            return GetLocalizedDict(cultureInfo.Name);
        }
        public Dictionary<string, string> GetLocalizedDict(  )
        {
            return GetLocalizedDict( CultureInfo.CurrentCulture );
        }
    }
