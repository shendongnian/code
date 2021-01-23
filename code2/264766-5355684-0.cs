    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;
    namespace sandbox
    {
        /// <summary>
        ///   <para>
        ///     Minimum scaffolding required for a custom exception.
        ///   </para>
        ///   <para>
        ///     Consider providing custom properties/fields to provide context and semantic details
        ///     regarding the exception instance. Alternatively, use the dictionary provided by the
        ///     base class for that purpose. See <see cref="System.Exception.Data"/> for more details.
        ///   </para>
        /// </summary>
        [Serializable]
        class MyCustomException : Exception
        {
            #region public constructors
            public MyCustomException() : base()
            {
                // set Message to the default localized message for your exception here
                // The base constructor for System.Exception sets InnerException to null as well as setting a default message.
                return ;
            }
            public MyCustomException( string message ) : base( message )
            {
                return ;
            }
            public MyCustomException( string message , Exception innerException ) : base( message , innerException )
            {
                return ;
            }
            #endregion public constructors
            #region serialization-related constructor/method
            /// <summary>
            /// protected constructor. Used for deserialization
            /// </summary>
            /// <param name="info"></param>
            /// <param name="context"></param>
            protected MyCustomException( SerializationInfo info , StreamingContext context ) : base( info , context )
            {
                // do other deserialization-related initialization here (e.g. set your object properties from info and context).
                return ;
            }
            /// <summary>
            /// Perform custom serialization
            /// </summary>
            /// <param name="info"></param>
            /// <param name="context"></param>
            [SecurityPermissionAttribute(SecurityAction.Demand,SerializationFormatter=true)]
            public override void GetObjectData( SerializationInfo info, StreamingContext context ) 
            {
                // do any serialization work required by your custom exception here
                base.GetObjectData( info, context );
                return ;
            }
            #endregion serialization-related constructor/method
        }
    }
