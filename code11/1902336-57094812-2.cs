    public partial class TestClass
    {
        public void CallDeactivate(int id, string modifiedBy)
        {
            var classType = typeof(TestClass);
            var deactivateMethod = classType.GetMethod("Deactivate");
            var parameterModifiedBy = deactivateMethod.GetParameters()[1];
            var notNullAttribute = parameterModifiedBy.CustomAttributes.FirstOrDefault();
            if (notNullAttribute.AttributeType == typeof(NotNullAttribute))
            {
                var attrObj = Activator.CreateInstance<NotNullAttribute>();
                attrObj.Validate(modifiedBy, parameterModifiedBy.Name);
                this.Deactivate(id, modifiedBy);
            }
        }
    }
