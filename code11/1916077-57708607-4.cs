    public class PetCommandHandler : BaseCommandHandler<PetCommand>
    {
        public PetCommandHandler(string type, string name) : base(type, name)
        {
        }
        public override void Run(PetCommand dCommand)
        {
            this.LogWrite(dCommand);
        }
    }
