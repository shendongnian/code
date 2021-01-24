     public class FallbackExceptionDestructurer : ExceptionDestructurer
     {
            public override Type[] TargetTypes => new[]
            {
                typeof(Exception),
            };
    
            public override void Destructure(
                Exception exception,
                IExceptionPropertiesBag propertiesBag,
                Func<Exception, IReadOnlyDictionary<string, object>> destructureException)
            {
                base.Destructure(exception, propertiesBag, destructureException);
            }
     }
