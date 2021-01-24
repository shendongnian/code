    public void Apply(PageApplicationModel model)
        {
            var defaultUIAttribute = model.ModelType.GetCustomAttribute<IdentityDefaultUIAttribute>();
            if (defaultUIAttribute == null)
            {
                return;
            }
            ValidateTemplate(defaultUIAttribute.Template);
            var templateInstance = defaultUIAttribute.Template.MakeGenericType(typeof(TUser));
            model.ModelType = templateInstance.GetTypeInfo();
        }
