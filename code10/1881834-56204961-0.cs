    private void HandleContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args) {
    	if (args.InRecycleQueue) {
    		if (item.Tag is string itemType) {
    			_recycleBin.EnqueueItemWithType(itemType, item); // NOTE Do your own book-keeping here
    			args.Handled = true; // NOTE Handle event only in case of recycle to prevent breaking x:Phase bindings
    		}
    	}
    }
