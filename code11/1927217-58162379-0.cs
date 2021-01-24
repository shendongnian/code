    public class SOOrderEntryExt : PXGraphExtension<SOOrderEntry>
    {
        public PXAction<SOOrder> UpdateDoc;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Recalculate Price")]
        public virtual IEnumerable updateDoc(PXAdapter adapter)
        {
            if (this.Base.Document.Current != null)
            {
                InventoryItemMaint itemMaint = PXGraph.CreateInstance<InventoryItemMaint>();
                /*you can access an instance of a BLC extension through the base BLC 
                 * object by using the GetExtension< T > (object)generic method of the PXGraph class*/
                var itemMaintExt = itemMaint.GetExtension<InventoryItemMaintExt>();
                foreach (SOLine line in this.Base.Transactions.Select())
                {
                    InventoryItem inventory = PXSelectorAttribute.Select<SOLine.inventoryID>(this.Base.Transactions.Cache, line, line.InventoryID) as InventoryItem;
                    if (inventory != null)
                    {
                        InventoryItem inventoryNew = itemMaintExt.UpdatePrice(itemMaint, inventory);
                        line.CuryUnitPrice = inventoryNew.BasePrice;
                        this.Base.Transactions.Update(this.Base.Transactions.Current);
                    }
                }
                this.Base.Save.PressButton();
            }
            return adapter.Get();
        }
    }
    public class InventoryItemMaintExt : PXGraphExtension<InventoryItemMaint>
    {
        public virtual InventoryItem UpdatePrice(InventoryItemMaint itemMaint,InventoryItem item)
        {
            if (item != null)
            {
                itemMaint.Item.Current = item;
                item.BasePrice = 500M;
                itemMaint.Item.Update(item);
                itemMaint.Save.PressButton();
            }
            return item;
        }
    }
