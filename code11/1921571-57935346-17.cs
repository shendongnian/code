    namespace ResponseLibrary
    {
        #region class Response
        /// <summary>
        /// This class is a response from an API call
        /// </summary>
        public class Response
        {
            #region Private Variables
            private int entitylineNumber;
            private string statusCode;
            private string entityUID;
            private string entityMark;
            #endregion
            #region Properties
        
                #region EntitylineNumber
                /// <summary>
                /// This property gets or sets the value for 'EntitylineNumber'.
                /// </summary>
                public int EntitylineNumber
                {
                    get { return entitylineNumber; }
                    set { entitylineNumber = value; }
                }
                #endregion
            
                #region EntityMark
                /// <summary>
                /// This property gets or sets the value for 'EntityMark'.
                /// </summary>
                public string EntityMark
                {
                    get { return entityMark; }
                    set { entityMark = value; }
                }
                #endregion
            
                #region EntityUID
                /// <summary>
                /// This property gets or sets the value for 'EntityUID'.
                /// </summary>
                public string EntityUID
                {
                    get { return entityUID; }
                    set { entityUID = value; }
                }
                #endregion
            
                #region StatusCode
                /// <summary>
                /// This property gets or sets the value for 'StatusCode'.
                /// </summary>
                public string StatusCode
                {
                    get { return statusCode; }
                    set { statusCode = value; }
                }
                #endregion
            
            #endregion
        }
        #endregion
       }
