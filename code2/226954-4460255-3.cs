    [Table(Name = "dbo.Groups")]
    public partial class Group
    {
        [Column(Storage = "_Id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id
        {
            get { return this._Id; }
            set { this._Id = value; }
        }
    
        [Column(Storage = "_ParentId", DbType = "Int")]
        public System.Nullable<int> ParentId
        {
            get { return this._ParentId; }
            set { this._ParentId = value; }
        }
        [Association(Name = "Group_Group", Storage = "_Children", ThisKey = "Id", OtherKey = "ParentId")]
        public EntitySet<Group> Children
        {
            get { return this._Children; }
            set { this._Children.Assign(value); }
        }    
    }
    
