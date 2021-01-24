    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    namespace TestConsole
    {
        public class EntityMetadata
        {
            [Required]
            public string Property { get; set; }
        }
        [MetadataType(typeof(EntityMetadata))]
        public partial class Entity
        {
        }
        public partial class Entity
        {
            public string Property { get; set; }
        }
        class Program
        {
            static void Main()
            {
                foreach (var type in typeof(Entity).Assembly.GetTypes())
                {
                    TypeDescriptor.AddProvider(new AssociatedMetadataTypeTypeDescriptionProvider(type), type);
                }
                Entity entity = new Entity();
                var context = new ValidationContext(entity, null, null);
                var results = new List<ValidationResult>();
                Validator.TryValidateObject(entity, context, results, true);
            }
        }
    }
