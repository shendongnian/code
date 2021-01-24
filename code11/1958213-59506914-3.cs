    public class CoolContextNumberOne : BotContexts {
        public override Command[] ContextSpecificCommands => Singleton.For(() => new Command[] { new CommandFoo() });
    }
    
    public class CoolContextNumberTwo : BotContexts {
        public override Command[] ContextSpecificCommands => Singleton.For(() => new Command[] { new CommandFoo() });
    }
