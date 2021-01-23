    public class DeleteItemCommand: BaseCommand
    {
        public int ItemId {get; set;}
        public override void Execute()
        {
            PrivateExecute(ItemId);
        }
        private void PrivateExecute(int itemId)
        {
            Contract.Requires<VeryBadThingHappendException>(itemId != default(int));
    
            var rep = AnyKindOfFactory.GetItemRepository();
            rep.DeleteItem(itemId);
        }
    }
