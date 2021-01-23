    public class EntryManager
    {
    	public EntryManager(Func<IEntrySetting, IEntry> entryFactory)
        {
            var entrySettings = this.settings.Load();
            foreach(var setting in entrySettings)
            {
                this.entries.Add(entryFactory(setting));
            }
        }
    }
    private static ILoader SelectLoader(IEntrySetting settings)
    {
        // your custom loader selection logic
    }
    var builder = new ContainerBuilder();
    builder.RegisterType<EntryManager>();
    builder.Register((c, p) => new Entry(SelectLoader(p.TypedAs<IEntrySetting>()))).As<IEntry>();
    IContainer container = builder.Build();
    container.Resolve<EntryManager>();
