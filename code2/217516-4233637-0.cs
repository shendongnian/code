    public class BootStrapper : Provider<ISession>
        {
            .....
            protected override ISession CreateInstance(IContext context)
            {
                return GetSession();
            }
            ....
        }
