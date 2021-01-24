    // in Constructor
    Messenger.Default.Register<JeffData.Messages.RecordStoreUpdatedMessage>(this, UpdateItem);
    private void UpdateItem(JeffData.Messages.RecordStoreUpdatedMessage recordStoreUpdatedMessage)
    {
        // here I can use ModelType now (a property of this class)
        if (recordStoreUpdatedMessage.Model.GetType() == ModelType && recordStoreUpdatedMessage.Model.Id == Model.Id)
        {
            Debug.WriteLine("DataTreeItemViewModel: cought RecordStoreUpdatedMessage with item: " + recordStoreUpdatedMessage.Model.GetType().ToString());
            Model = recordStoreUpdatedMessage.Model;
        }
    }
