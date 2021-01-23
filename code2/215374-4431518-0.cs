    public partial class Products
    {
        protected override void BeforeInsert()
        {
            Schema.GetColumn(Columns.CreatedOn).IsReadOnly = true;
            base.BeforeInsert();
            Schema.GetColumn(Columns.CreatedOn).IsReadOnly = false;
        }
        protected override void BeforeUpdate()
        {
            Schema.GetColumn(Columns.ModifiedOn).IsReadOnly = true;
            base.BeforeUpdate();
            Schema.GetColumn(Columns.ModifiedOn).IsReadOnly = false;
        }
    }
