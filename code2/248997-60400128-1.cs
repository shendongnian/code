    public class TypeExtensionTests
    {
        [Theory]
        [InlineData(typeof(string), typeof(IList<int>), false)]
        [InlineData(typeof(List<>), typeof(IList<int>), false)]
        [InlineData(typeof(List<>), typeof(IList<>), true)]
        [InlineData(typeof(List<int>), typeof(IList<>), true)]
        [InlineData(typeof(List<int>), typeof(IList<int>), true)]
        [InlineData(typeof(List<int>), typeof(IList<string>), false)]
        public void ValidateTypeImplementsInterface(Type type, Type @interface, bool expect)
        {
            var output = type.ImplementsInterface(@interface);
            Assert.Equal(expect, output);
        }
    }
