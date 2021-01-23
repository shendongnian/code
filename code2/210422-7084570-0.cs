        [TestMethod]
        public void IsValid_Returns_ValidationResult_Errors_When_Properties_With_Meta_Data_Are_Not_Valid()
        {
            var sut = new User
                          {
                              Login = "too long!!!"
                          };
            var actual = sut.IsValid();
            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(1, actual[0].MemberNames.Count());
            var firstValidationError = actual[0];
            Assert.AreEqual("Login", firstValidationError.MemberNames.First());
            Assert.AreEqual("The field Login must be a string with a maximum length of 4.", firstValidationError.ErrorMessage);
        }
        [TestMethod]
        public void IsValid_Returns_Empty_List_Of_Errors_When_Properties_With_Meta_Data_Are_Valid()
        {
            var sut = new User
                          {
                              Login = "abcd"
                          };
            var actual = sut.IsValid();
            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count);
        }
    [MetadataType(typeof(UserMetaData))]
    public partial class User : BaseEntity
    {
        public string Login { get; set; }
        public class UserMetaData
        {
            [Required]              
            [StringLength(4)]       
            public string Login { get; set; }
        }
    }
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            RegisterMetadata();
        }
        private void RegisterMetadata()
        {
            var currentType = GetType();
            var metadataType = GetMetadataType();
            if (metadataType == null)
                return;
            var descriptorProvider = new AssociatedMetadataTypeTypeDescriptionProvider(currentType, metadataType);
            TypeDescriptor.AddProviderTransparent(descriptorProvider, currentType);
        }
        private Type GetMetadataType()
        {
            var attribute = Attribute.GetCustomAttributes(this.GetType()).ToList().Find(t => t is MetadataTypeAttribute);
            return (attribute != null)
                       ? ((MetadataTypeAttribute)attribute).MetadataClassType
                       : null;
        }
        public virtual List<ValidationResult> IsValid()
        {
            var validationErrors = new List<ValidationResult>();
            var context = new ValidationContext(this, null, null);
            Validator.TryValidateObject(this, context, validationErrors, true);
            return validationErrors;
        }
    }
