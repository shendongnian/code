public class SessionStorage
	{
		private Dictionary<string, string> Names { get; set; }
		public SessionStorage()
		{
			Names = new Dictionary<string, string>();
		}
		public void Activate( string sessionId, string name )
		{
			Names[ name ] = sessionId;
		}
		public void Deactivate( string sessionId )
		{
			string name = ( from n in Names where n.Value == sessionId select n.Key ).FirstOrDefault();
			if ( name == null )
				return;
			Names.Remove( name );
		}
		public bool IsActive( string name )
		{
			return Names.ContainsKey( name );
		}
	}
