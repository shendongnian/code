    [ContractClass(typeof(IEnginecontract))]
    public interface IEngine : IInitialise 
    {
        ICommandManager CommandManager { get; }
        IDictionary<int, IEntity> World { get; } 
    }
    [ContractClassFor(typeof(IEngine))]
    public abstract class IEnginecontract : IEngine
    {
        public ICommandManager CommandManager
        {
            get
            {
                Contract.Ensures(Contract.Result<ICommandManager>() != null);
                return default(ICommandManager);
            }
        }
        public IDictionary<int, IEntity> World
        {
            get
            {
                Contract.Ensures(Contract.Result<IDictionary<int, IEntity>>() != null);
                return default(IDictionary<int, IEntity>);
            }
        }
        public abstract bool IsInitialised {get;}
        public abstract void Initialise();
    }
