    [Serializable]
        [LazyLoadingAspect(AttributeExclude=true)]
        [MulticastAttributeUsage(MulticastTargets.Property)]
        public class LazyLoadingAspectAttribute : LocationInterceptionAspect
        {
            public object DefaultValue {get; set;}
    
            public override void OnGetValue(LocationInterceptionArgs args)
            {
               args.ProceedGetValue();
                if (args.Value != null)
                {
                  return;
                }
    
                args.Value = DefaultValue;
                args.ProceedSetValue();
            }
    
        }
