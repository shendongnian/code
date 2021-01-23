    public class SomeClass
    {
        ICommandInvoker invoker;
        public SomeClass(ICommandInvoker invoker)
        {
            this.invoker = invoker;
        }
        public void DoSomething()
        {
            var command = new ChangeNameCommand(1, "asdf");
            invoker.Invoke(command);
        }
    }
