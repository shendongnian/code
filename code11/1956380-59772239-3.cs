    public interface IMockable<T> where T : class
    {
        Mock<T> CreateMock();
    }
    [Conditional( "DEBUG" )] // Exclude mocking interceptor in release builds.
    public class MockAspect : TypeLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects( object targetElement )
        {
            Type targetType = (Type) targetElement;
            yield return new AspectInstance( targetElement, (IAspect) Activator.CreateInstance( typeof( MockAspectImpl<> ).MakeGenericType( targetType ) ) );
        }
    }
    [PSerializable]
    // Make sure we are ordered after our aspect PostSharpExecuteAfterMethod.
    [AspectTypeDependency(AspectDependencyAction.Order, AspectDependencyPosition.After, typeof( PostSharpExecuteAfterMethod ))]
    public class MockAspectImpl<T> : IInstanceScopedAspect, IAdviceProvider, IMockable<T> where T : class
    {
        [PNonSerialized]
        private Mock<T> mock;
        public object CreateInstance( AdviceArgs adviceArgs )
        {
            return new MockAspectImpl<T>();
        }
        public void RuntimeInitializeInstance()
        {
        }
        public IEnumerable<AdviceInstance> ProvideAdvices( object targetElement )
        {
            yield return new IntroduceInterfaceAdviceInstance( typeof( IMockable<T> ) );
        }
        Mock<T> IMockable<T>.CreateMock()
        {
            this.mock = new Mock<T>();
            return this.mock;
        }
        [OnMethodInvokeAdvice]
        [MulticastPointcut( Targets = MulticastTargets.Method,
                            Attributes = MulticastAttributes.Instance | MulticastAttributes.Public | MulticastAttributes.Virtual )]
        public void OnMethodInvoke( MethodInterceptionArgs args )
        {
            if ( this.mock != null )
            {
                args.ReturnValue = args.Method.Invoke( mock.Object, args.Arguments.ToArray() );
            }
            else
            {
                args.Proceed();
            }
        }
    }
