     public class MyAspect : TypeLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            yield return Create<MethodInfo>(mi, "Value");
            
        }
    
        private AspectInstance Create<T>(T target, string newName)
        {
            var x = new CustomAttributeIntroductionAspect(
                new ObjectConstruction(typeof(NewMethodName).GetConstructor(new Type[] { typeof(string) }), new object[] { newName })
                );
    
            return new AspectInstance(target, x);
        }
    }
