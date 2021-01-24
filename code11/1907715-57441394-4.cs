    [TestFixture]
    public class Tests
    {
        [Test]
        public void ReferencedAssembliesDoNOtThrow()
        {
            Assert.DoesNotThrow(() => ExceptionHelper<PlatformNotSupportedException>.ThrowIfDetected(yourAssembly.ReflectionOnlyLoadReferencedAssemblies()));
        }
    }
