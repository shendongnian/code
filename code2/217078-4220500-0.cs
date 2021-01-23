    [DataContract(Namespace = Constants.OrgStructureNamespace)]
    public class EntityInfo : IExtensibleDataObject
    {
        public Guid EntityID { get; set; }
        [DataMember(Name="EntityID")]
        byte[] EntityIDBytes
        {
            get { return this.EntityID.ToByteArray(); }
            set { this.EntityID = new Guid(value); }
        }
        [DataMember]
        public EntityType EntityType { get; set; }
        [DataMember]
        public IList<Guid> EntityVersions { get; set; }
        [DataMember]
        public IList<Guid> OrganisationStructures { get; set; }
        #region IExtensibleDataObject Members
        // ...
        #endregion
    }
