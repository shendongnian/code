    partial class MyEntity
    {
        void ApplyChanges(MyEntity changedEntity)
        {
            this.PrimaryKey = changeEntity.PrimaryKey;
            this.Name = changedEntity.Name;
            this.Age = changedEntity.Age;
        }
    }
