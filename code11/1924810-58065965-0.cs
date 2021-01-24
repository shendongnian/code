        public HtmlSanitizer(IEnumerable<string> allowedTags = null, IEnumerable<string> allowedSchemes = null,
            IEnumerable<string> allowedAttributes = null, IEnumerable<string> uriAttributes = null, IEnumerable<string> allowedCssProperties = null, IEnumerable<string> allowedCssClasses = null)
        {
            AllowedTags = new HashSet<string>(allowedTags ?? DefaultAllowedTags, StringComparer.OrdinalIgnoreCase);
            AllowedSchemes = new HashSet<string>(allowedSchemes ?? DefaultAllowedSchemes, StringComparer.OrdinalIgnoreCase);
            AllowedAttributes = new HashSet<string>(allowedAttributes ?? DefaultAllowedAttributes, StringComparer.OrdinalIgnoreCase);
            UriAttributes = new HashSet<string>(uriAttributes ?? DefaultUriAttributes, StringComparer.OrdinalIgnoreCase);
            AllowedCssProperties = new HashSet<string>(allowedCssProperties ?? DefaultAllowedCssProperties, StringComparer.OrdinalIgnoreCase);
            AllowedAtRules = new HashSet<CssRuleType>(DefaultAllowedAtRules);
            AllowedCssClasses = allowedCssClasses != null ? new HashSet<string>(allowedCssClasses) : null;
        }
