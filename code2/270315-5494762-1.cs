            if(modelValidator is DataAnnotationsModelValidator){
                 var attribute = ((DataAnnotationsModelValidator)modelValidator).Attribute;
                 if(attribute != null && string.IsNullOrEmpty(attribute.ErrorMessage)){
                        var attributeName = attribute.GetType().Name.Replace("Attribute", string.Empty);
                        attribute.ErrorMessage = resourceManager.GetString(attributeName, culture);
                    }
                 }
            } 
        }</s>
