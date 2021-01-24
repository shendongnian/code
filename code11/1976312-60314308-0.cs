    public interface IItemUsage
    {
        void Execute(IItemUsageArgs args);
    }
    public interface IItemUsageArgs
    {
        //place public part of all ItemUsageArgs
    }
    public class ItemUsageArgs1 : IItemUsageArgs
    {
    }
    public class ItemUsageArgs2 : IItemUsageArgs
    {
    }
    public class ItemUsage1 :IItemUsage
    {
        public void Execute(ItemUsageArgs1 args)
        {
            //do you need
        }
        void IItemUsage.Execute(IItemUsageArgs args)
        {
            Execute(args as ItemUsageArgs1);
        }
    }
    public class ItemUsage2 : IItemUsage
    {
        public void Execute(ItemUsageArgs2 args)
        {
            //do you need
        }
        void IItemUsage.Execute(IItemUsageArgs args)
        {
            Execute(args as ItemUsageArgs2);
        }
    }
