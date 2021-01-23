        /// <summary>
        /// A data transfer object is sent between layers.  It has a few base properties
        /// as well as a list of payload objects.
        /// </summary>
        [DataContract(Namespace= SharedModelNamespace.Namespace.SharedModel)]
        public class DataTransferObject
        {
            /// <summary>
            /// As part of the data transfer object, it specifies what environment to connect
            /// to should it make a DAL call.
            /// </summary>
            [DataMember]
            public string DataEnvironment {get; set };
                  
            /// <summary>
            /// These are the list of objects (the payload) that will be transferred
            /// back and forth from the server to the client.
            /// </summary>
            [DataMember]
            public List<BasePOCO> DataTransferObjects { get; set; }
