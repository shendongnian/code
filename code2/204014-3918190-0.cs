partial void OnContextCreated() {
    this.SavingChanges += Context_SavingChanges;
}
void Context_SavingChanges(object sender, EventArgs e) {
    IEnumerable<ObjectStateEntry> objectStateEntries =
            from ose
            in this.ObjectStateManager.GetObjectStateEntries(EntityState.Added | 
                                                            EntityState.Modified)
            where ose.Entity is Product
            select ose;
    Product product = objectStateEntries.Single().Entity as Product;
            
    product.ModifiedDate = DateTime.Now;
    product.ComplexProperty.Revision++;
}
