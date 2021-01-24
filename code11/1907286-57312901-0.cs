public class ContactRepository:Repository<Contact>, IContactRepository
{
        private IContactRepository _contractRepo;
        // In order to resolve IContractRepository, the container has to 
        // resolve another IContractRepository to inject into it. 
        // And another one to inject into that. It's recursive.
        public ContactRepository(IContactRepository contractRepo)
        {
            this._contractRepo = contractRepo;
        }
}
Your example doesn't show how `ContactRepository` uses the `IContactRepository` that gets inject into it. But this
    public interface IContactRepository:IRepository<Contact>
    {
    }
reveals that it's using the exact same methods found in `IRepository<Contact>`, because `IContactRepository` doesn't have any methods other than those.
So you most likely just need to modify `ContactRepository` to inject `IRepository<Contact>`, not `IContactRepository`.
public class ContactRepository:Repository<Contact>, IContactRepository
{
        private IRepository<Contact> _contractRepo;
        public ContactRepository(IRepository<Contact> contractRepo)
        {
            this._contractRepo = contractRepo;
        }
}
That could be easy to overlook since both interfaces have exactly the same methods.
