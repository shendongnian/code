        public IEnumerable GetClientValidationRules(System.Web.Mvc.ModelMetadata metadata, ControllerContext context)
        {
            var clientValidationRule = new ModelClientValidationRule()
            {
                ErrorMessage = FormatErrorMessage(ErrorMessage),
                ValidationType = "required"
            };
            yield return new[] { clientValidationRule };
        }
