    public class WebWizForumVersion
    {
        // Properties of returned data
        public string Software { get; private set; }
        public string Version { get; private set; }
        public string APIVersion { get; private set; }
        public string Copyright { get; private set; }
        public string BoardName { get; private set; }
        public string URL { get; private set; }
        public string Email { get; private set; }
        public string Database { get; private set; }
        public string InstallID { get; private set; }  // changed property name
        public bool NewsPad { get; private set; }
        public string NewsPadURL { get; private set; }
    
        public WebWizForumVersion( XmlReader Data )
        {
            try
            {
                PropertyInfo[] props = this.GetType().GetProperties();
    
                foreach( PropertyInfo pi in props )
                {
                    Data.ReadToFollowing( pi.Name );
                    if( pi.PropertyType == typeof( bool ) )
                    {
                        pi.SetValue( this, bool.Parse( Data.ReadElementContentAsString() ), null );
                    }
                    else
                    {
                        pi.SetValue( this, Data.ReadElementContentAsString(), null );
                    }
                }
            }
            catch( Exception e )
            {
              // do something with exception
            }
        }
    }
