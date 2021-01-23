                public override void Validate(object value)
            {
                CredentialConfigurationElement element = (CredentialConfigurationElement)value;
                if (!element.ElementInformation.IsPresent)
                    return; //IsRequired is handle by the framework, don't throw error here  only throw an error if the element is present and it fails validation.
                if (string.IsNullOrEmpty(element.UserName) || string.IsNullOrEmpty(element.Password))
                    throw new ConfigurationErrorsException("The restCredentials element is missing one or more required Attribute: userName or password.");
            }
