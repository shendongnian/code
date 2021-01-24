                Customer customer = new Customer();
            CustomerCriticalValidator criticalValidator = new CustomerCriticalValidator();
            CustomerWarningValidator warningValidator = new CustomerWarningValidator();
            var validationResult = criticalValidator.Validate(customer);
            if (validationResult.IsValid)
            {
                var result = warningValidator.Validate(customer);
                if (!result.IsValid)
                {
                    //DO what you need with customer    
                }
                
            }
