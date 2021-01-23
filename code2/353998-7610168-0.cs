    public class DeleteItemCommand
    {
        public DeleteItemCommand(int itemId)
        {
            Contract.Requires<VeryBadThingHappendException>(itemId!= default(int));
            ItemId = itemId;
        }
    
        public int ItemId {get; private set;}
        public void Execute()
        {   
            var if = AnyKindOfFactory.GetItemRepository();
            if.DeleteItem(ItemId);
        }
    }
