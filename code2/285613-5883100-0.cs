        public class CreateAccidentCommandMetadata : ModelMetadataConfiguration<CreateAccidentCommand>
    {
        public CreateAccidentCommandMetadata()
        {
            Configure(x => x.TrackingNumber)
                .Required();
            Configure(x => x.CategoryId)
                .Required()
                .DisplayName("Category")
                .Template(MVC.Accident.Views.EditorTemplates.Category);
        }
    }
