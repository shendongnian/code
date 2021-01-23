    public class AddUserHandler : ICommandHandler<AddUser>
    {
        public void Execute(object command)
        {
            Execute((AddUser)command);
        }
        public void Execute(AddUser command)
        {
            Console.WriteLine("{0}: User added: {1}", GetType().Name, command.Name);
        }
    }
