    public void RefreshCollection()
    {
        using (var dataContext = CreateDataContext())
        {
            // On va chercher les données complête de la table.
            purchaseOrders = from po in dataContext.PurchaseOrders
                             orderby po.PurchaseOrderId ascending
                             select po;
        }
    }
    private void sauvegarderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using (var dataContext = CreateDataContext())
        {
            purchaseOrder.OrderDate = orderDate.Value;
            purchaseOrder.RequiredDate = requiredDate.Value;
            purchaseOrder.ShipTo = shipTo.Text;
            purchaseOrder.State = helper.ConvertComboBoxIndexToStateIndex(
                stateKey.SelectedIndex);
        
            // On cast un autre type pour le forcer à être un ComboBoxItem
            var supplierItem = (ComboBoxItem)supplierId.SelectedItem;
            purchaseOrder.SupplierId = supplierItem.Id;
        
            dataContext.SubmitChanges();
        } 
    }
