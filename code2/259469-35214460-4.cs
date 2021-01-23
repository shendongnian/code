    namespace System.Web.Mvc
    {
        // From https://aspnetwebstack.codeplex.com/SourceControl/latest#src/System.Web.Mvc/DataAnnotationsModelValidator.cs
        // commit 5fa60ca38b58, Apr 02, 2015
        // Only diff is adding of secton guarded by THERE_IS_A_BETTER_EXTENSION_POINT
        public class DataAnnotationsModelValidatorEx : DataAnnotationsModelValidator
        {
            readonly bool _shouldHotwireValidationContextServiceProviderToDepdenencyResolver;
    
            public DataAnnotationsModelValidatorEx(
                ModelMetadata metadata, ControllerContext context, ValidationAttribute attribute,
                bool shouldHotwireValidationContextServiceProviderToDepdenencyResolver=false)
                : base(metadata, context, attribute)
            {
               _shouldHotwireValidationContextServiceProviderToDependencyResolver =
                    shouldHotwireValidationContextServiceProviderToDependencyResolver;
            }
        }
    }
