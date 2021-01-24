    [TestFixture]
    public class Tests
    {
        [Test]
        public void ReferencedAssembliesDoNOtThrowPlatformNotSupportedException()
        {
            Assert.DoesNotThrow(() => ExceptionHelper<PlatformNotSupportedException>.ThrowIfDetected(yourAssembly.ReflectionOnlyLoadReferencedAssemblies()));
        }
    }
