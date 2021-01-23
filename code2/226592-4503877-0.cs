     [HasAndBelongsToMany(typeof(DocumentVersionEntity),
                         RelationType.Bag,
                         Table = "DocumentEntriesToDocumentVersions", 
                         ColumnKey = "DocumentEntryId", 
                         ColumnRef = "DocumentVersionId", 
                         Cascade = ManyRelationCascadeEnum.AllDeleteOrphan, 
                         Lazy = true)]
        public virtual IList<DocumentVersionEntity> Versions
        {
            get { return _versions; }
            set { _versions = value; }
        }
