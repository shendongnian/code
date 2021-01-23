    public class RegisterAssetCommandHandler
        : ICommandHandler<RegisterAssetCommand>
    {
        public RegisterAssetCommandHandler(
            ILawbaseAssetRepository lawbaseAssetRepository,
            IAssetChecklistKctcPartRepository assetRepository)
        {
            // ...
        }
        public void Handle(RegisterAssetCommand command)
        {
            // Validate the command
            // Execute the command
        }
    }
