    public class RegisterAssetCommandHandler
        : ICommandHandler<RegisterAssetCommand>
    {
        private ILawbaseAssetRepository lawbaseAssetRepository;
        private IAssetChecklistKctcPartRepository assetRepository;
        public RegisterAssetCommandHandler(
            ILawbaseAssetRepository lawbaseAssetRepository,
            IAssetChecklistKctcPartRepository assetRepository)
        {
            this.lawbaseAssetRepository = lawbaseAssetRepository;
            this.assetRepository = assetRepository;
        }
        public void Handle(RegisterAssetCommand command)
        {
            // Optionally validate the command
            // Execute the command
        }
    }
