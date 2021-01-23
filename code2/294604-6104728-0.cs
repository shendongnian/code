            public static void AddExceptionMessageAsValidator(Page page, Exception ex, string message, string validationGroup)
        {
            CustomValidator exValidator = new CustomValidator();
            exValidator.IsValid = false;
            if (message != null)
                exValidator.ErrorMessage = message;
            else
                exValidator.ErrorMessage = ex.Message;
            exValidator.Text = String.Empty;
            if (!String.IsNullOrEmpty(validationGroup))
                exValidator.ValidationGroup = validationGroup;
            page.Validators.Add(exValidator);
        }
