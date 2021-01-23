    /// <summary>
    /// A general, base error for GS3 applications </summary>
    [Serializable]
    public class Gs3Exception : ApplicationException {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gs3Exception"/> class </summary>
        public Gs3Exception() {}
        /// <summary>
        /// Initializes a new instance of the <see cref="Gs3Exception"/> class </summary>
        /// <param name="message">A brief, descriptive message about the error </param>
        public Gs3Exception(string message) : base(message) {}
        /// <summary>
        /// Initializes a new instance of the <see cref="Gs3Exception"/> class 
        /// when deserializing </summary>
        /// <param name="info">The object that holds the serialized object data </param>
        /// <param name="context">The contextual information about the source or
        ///  destination.</param>
        public Gs3Exception(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Gs3Exception"/> class
        /// with a message and inner exception </summary>
        /// <param name="Message">A brief, descriptive message about the error </param>
        /// <param name="exc">The exception that triggered the failure </param>
        public Gs3Exception(string Message, Exception exc) : base(Message, exc) { }
    }
    /// <summary>
    /// An object queried in an request was not found </summary>
    [Serializable]
    public class ObjectNotFoundException : Gs3Application {
        private string objectName = string.Empty;
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectNotFoundException"/> class </summary>
        public ObjectNotFoundException() {}
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectNotFoundException"/> class </summary>
        /// <param name="message">A brief, descriptive message about the error</param>
        public ObjectNotFoundException(string message) : base(message) {}
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectNotFoundException"/> class </summary>
        /// <param name="ObjectName">Name of the object not found </param>
        /// <param name="message">A brief, descriptive message about the error </param>
        public ObjectNotFoundException(string ObjectName, string message) : this(message) {
            this.ObjectName = ObjectName;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectNotFoundException"/> class.
        /// This method is used during deserialization to retrieve properties from 
        /// the serialized data. </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or
        /// destination.</param>
        public ObjectNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) {
            if (null != info) {
                this.objectName = info.GetString("objectName");
            }
        }
        /// <summary>
        /// When serializing, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"/> 
        /// with information about the exception. </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds 
        /// the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="info"/> parameter is a null reference (Nothing in Visual Basic) </exception>
        /// <PermissionSet>
        ///     <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*"/>
        ///     <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter"/>
        /// </PermissionSet>
        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context) {
            base.GetObjectData(info, context);
            
            //  'info' guaranteed to be non-null (base.GetObjectData() will throw an ArugmentNullException if it is)
            info.AddValue("objectName", this.objectName);
        }
        /// <summary>
        /// Gets or sets the name of the object not found </summary>
        /// <value>The name of the object </value>
        public string ObjectName {
            get { return objectName; }
            set { objectName = value; }
        }
    }
