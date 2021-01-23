    ICommandExecutor
    {
        Execute(BaseCommand source);
    }
    public abstract class BaseCommand
    {
        public ICommandExecutor Executor { get; private set; }
        public void Execute() 
        {
            this.Executor.Execute(this);
            State = CommandState.Executed;
        }
    }
    
    public class DeleteCommandExecutor : ICommandExecutor
    {
        public void Execute(BaseCommand source)
        {
            Contract.Requires<VeryBadThingHappendException>(source.ItemId != default(int));
            var if = AnyKindOfFactory.GetItemRepository();
            if.DeleteItem(ItemId);
        }
    }
