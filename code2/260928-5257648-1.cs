    /// <summary>
    /// <para>This class provides a direct implementation of the IPathHelper for the API implementation
    /// and manages all the paths inside the DataHomeFolder structure for the TenForce application.</para>
    /// </summary>
    [DataContract]
    public class PathHelper : Objects.Helpers.IPathHelper
    {
        #region Private Fields
        [DataMember]
        private readonly ParameterBUL _mParameterBul;
        private const Parameter.ParameterId DataHomeFolderId = Parameter.ParameterId.DataHomeFolder;
        private const Parameter.ParameterId CompanyNameId = Parameter.ParameterId.CompanyName;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// <para>Creates a new instance of the PathHelper class</para>
        /// </summary>
        public PathHelper()
        {
            _mParameterBul = new ParameterBUL();
        }
    
        #endregion
    
        #region IPathHelper Members
    
        /// <summary>
        /// <para>Returns the absolute path to the DataHomeFolder of the TenForce Application.</para>
        /// </summary>   
        public string ApplicationFolder
        {
            get
            {
                return CreatePath(_mParameterBul.GetParameterValue(DataHomeFolderId));
            }
        }
    
        /// <summary>
        /// <para>Returns the absolute path to the Company DataHomeFolder.</para>
        /// </summary>   
        public string CompanyHomeFolder
        {
            get
            {
                return CreatePath(Path.Combine(ApplicationFolder, _mParameterBul.GetParameterValue(CompanyNameId)));
            }
        }
    
        /// <summary>
        /// <para>Returns the absolute path to the Company custom folder.</para>
        /// </summary>
        public string CustomFolder
        {
            get
            {
                return CreatePath(Path.Combine(CompanyHomeFolder, @"custom"));
            }
        }
    
        /// <summary>
        /// <para>Returns the absolute path to the Company wiki folder.</para>
        /// </summary>
        public string WikiFolder
        {
            get
            {
                return CreatePath(Path.Combine(CompanyHomeFolder, @"wiki"));
            }
        }
    
        /// <summary>
        /// <para>Returns the absolute path to the Company addins folder.</para>
        /// </summary>    
        public string AddinsFolder
        {
            get
            {
                return CreatePath(Path.Combine(CompanyHomeFolder, @"addins"));
            }
        }
    
        #endregion
    
        #region Private Members
    
        /// <summary>
        /// <para>Checks if the specified path exists, and creates the path 
        /// if the system cannot find it.</para>
        /// </summary>
        /// <param name="path">The path to verify.</param>
        private static string CreatePath(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }
    
        #endregion
    }
