    public class ChangeNameCommand : IDomainCommand
    {
        public ChangeNameCommand(int personId, string newName)
        {
            this.PersonId = personId;
            this.NewName = newName;
        }
        public int PersonId { get; set; }
        public string NewName { get; set; }
    }
