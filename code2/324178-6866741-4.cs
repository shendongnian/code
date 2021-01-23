    public class UnitOfWorkInvoker : ICommandInvoker
    {
        Autofac.ILifetimeScope scope;
        public UnitOfWorkInvoker(Autofac.ILifetimeScope scope)
        {
            this.scope = scope;
        }
        public void Invoke<TCommand>(TCommand command) where TCommand : IDomainCommand
        {
            using (var workScope = scope.BeginLifetimeScope("UnitOfWork")) // step 1
            {
                var handler = workScope.Resolve<IHandle<TCommand>>(); // step 3 (implies step 2)
                handler.Handle(command); // step 4
                var session = workScope.Resolve<NHibernate.ISession>();
                session.Transaction.Commit(); // step 5
            } // step 6 - When the "workScope" is disposed, Autofac will dispose the ISession.
              // If an exception was thrown before the commit, the transaction is rolled back.
        }
    }
