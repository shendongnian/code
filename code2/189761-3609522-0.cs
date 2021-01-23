    using System;
    using System.Collections;
    using System.Runtime.Serialization;
    
    namespace Common.CustomExceptions
    {
    
        /// <summary>
        /// Custom exception.
        /// </summary>
        [Serializable]
        public class CustomExceptionBase: ApplicationException
            {
    
            // Local private members
            protected DateTime _dateTime = DateTime.Now;
            protected String _machineName = Environment.MachineName;
            protected String _exceptionType = "";
            private String _exceptionDescription = "";
            protected String _stackTrace = "";
            protected String _assemblyName = "";
            protected String _messageName = "";
            protected String _messageId = "";
            protected Hashtable _data = null;
            protected String _source = "";
            protected Int32 _exceptionNumber = 0;
    
            public CustomExceptionBase(): base()
            {
                if (Environment.StackTrace != null)
                    this._stackTrace = Environment.StackTrace;
            }
    
            public CustomExceptionBase(Int32 exceptionNumber): base()
            {
                this._exceptionNumber = exceptionNumber;
                if (Environment.StackTrace != null)
                    this._stackTrace = Environment.StackTrace;
            }
    
            public CustomExceptionBase(Int32 exceptionNumber, String message): base(message)
            {
                this._exceptionNumber = exceptionNumber;
                if (Environment.StackTrace != null)
                    this._stackTrace = Environment.StackTrace;
            }
    
            public CustomExceptionBase(Int32 exceptionNumber, String message, Exception innerException): 
                base(message, innerException)
            {
                this._exceptionNumber = exceptionNumber;
                if (Environment.StackTrace != null)
                    this._stackTrace = Environment.StackTrace;
            }
    
            public CustomExceptionBase(Int32 exceptionNumber, String message, Exception innerException, String messageName, String mqMessageId): 
                base(message, innerException)
            {
                this._exceptionNumber = exceptionNumber;
                this._messageId = mqMessageId;
                this._messageName = messageName;
                if (Environment.StackTrace != null)
                    this._stackTrace = Environment.StackTrace;
            }
    
            public CustomExceptionBase(Int32 exceptionNumber, String message, Exception innerException, String messageName, String mqMessageId, String source): 
                base(message, innerException)
            {
                this._exceptionNumber = exceptionNumber;
                this._messageId = mqMessageId;
                this._messageName = messageName;
                this._source = source.Equals("") ? this._source : source;
                if (Environment.StackTrace != null)
                    this._stackTrace = Environment.StackTrace;
            }
    
    
            #region ISerializable members
    
            /// <summary>
            /// This CTor allows exceptions to be marhalled accross remoting boundaries
            /// </summary>
            /// <param name="info"></param>
            /// <param name="context"></param>
            protected CustomExceptionBase(SerializationInfo info, StreamingContext context) :
                base(info,context)
            {
                this._dateTime = info.GetDateTime("_dateTime");
                this._machineName = info.GetString("_machineName");
                this._stackTrace = info.GetString("_stackTrace");
                this._exceptionType = info.GetString("_exceptionType");
                this._assemblyName = info.GetString("_assemblyName");
                this._messageName = info.GetString("_messageName");
                this._messageId = info.GetString("_messageId");
                this._exceptionDescription = info.GetString("_exceptionDescription");
                this._data = (Hashtable)info.GetValue("_data", Type.GetType("System.Collections.Hashtable"));
            }
    
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("_dateTime", this._dateTime);
                info.AddValue("_machineName", this._machineName);
                info.AddValue("_stackTrace", this._stackTrace);
                info.AddValue("_exceptionType", this._exceptionType);
                info.AddValue("_assemblyName", this._assemblyName);
                info.AddValue("_messageName", this._messageName);
                info.AddValue("_messageId", this._messageId);
                info.AddValue("_exceptionDescription", this._exceptionDescription);
                info.AddValue("_data", this._data, Type.GetType("System.Collections.Hashtable"));
                base.GetObjectData (info, context);
            }
    
            #endregion
        }
    }
