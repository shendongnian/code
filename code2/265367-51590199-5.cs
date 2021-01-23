    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web.Http.Controllers;
    using System.Web.Http.Metadata;
    using System.Web.Http.Validation;
    
    namespace your_namespace.Web.Http.Validation
    {
        public class IgnoreRequiredOrDefaultBodyModelValidator : DefaultBodyModelValidator
        {
            private static ConcurrentDictionary<HttpActionBinding, bool> _ignoreRequiredValidationByActionBindingCache;
    
            static IgnoreRequiredOrDefaultBodyModelValidator()
            {
                _ignoreRequiredValidationByActionBindingCache = new ConcurrentDictionary<HttpActionBinding, bool>();
            }
    
            protected override bool ShallowValidate(ModelMetadata metadata, BodyModelValidatorContext validationContext, object container, IEnumerable<ModelValidator> validators)
            {
                var actionContext = validationContext.ActionContext;
    
                if (RequiredValidationsIsIgnored(actionContext.ActionDescriptor.ActionBinding))
                    validators = validators.Where(v => !v.IsRequired);			
    
                return base.ShallowValidate(metadata, validationContext, container, validators);
            }
    
            #region RequiredValidationsIsIgnored
            private bool RequiredValidationsIsIgnored(HttpActionBinding actionBinding)
            {
                bool ignore;
    
                if (!_ignoreRequiredValidationByActionBindingCache.TryGetValue(actionBinding, out ignore))
                    _ignoreRequiredValidationByActionBindingCache.TryAdd(actionBinding, ignore = RequiredValidationsIsIgnored(actionBinding.ActionDescriptor as ReflectedHttpActionDescriptor));
    
                return ignore;
            }
    
            private bool RequiredValidationsIsIgnored(ReflectedHttpActionDescriptor actionDescriptor)
            {
                if (actionDescriptor == null)
                    return false;
    
                return actionDescriptor.MethodInfo.GetCustomAttribute<IgnoreRequiredValidationsAttribute>(false) != null;
            } 
            #endregion
        }
    
        [AttributeUsage(AttributeTargets.Method, Inherited = true)]
        public class IgnoreRequiredValidationsAttribute : Attribute
        {
    
        }
    }
