    private bool VisitElement(CsElement element, CsElement parentElement, object context)
        {
            #region Namespace rules
            if (!element.Generated && element.ElementType == ElementType.Namespace)
            {
                var @namespace = element.Declaration.Name;
                var companyName = NamespaceUtils.GetNamespaceToken(@namespace, NamespaceTokenType.Company);
                //Flag a "Violation" is the element doesn't start with an allowed company name
                if (!NamespaceUtils.ValidateNamespaceCompany(companyName))
                {
                    AddViolation(parentElement, element.LineNumber, "NamespaceMustBeginWithAllowedCompanyName", companyName);
                }
            #endregion
            #region Fields rules
            if (!element.Generated && element.ElementType == ElementType.Field)
            {
                var fieldName = element.Declaration.Name;
                // Flag a violation if the instance variables are not prefixed with an underscore.
                if (element.ActualAccess != AccessModifierType.Public &&
                    element.ActualAccess != AccessModifierType.Internal &&
                    fieldName.ToCharArray()[0] != '_')
                {
                    AddViolation(parentElement, element.LineNumber, "FieldNamesMustBeginWithUnderscore", fieldName);
                }
            }
            #endregion
            return true;
        }
