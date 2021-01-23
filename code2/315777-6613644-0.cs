        [Test]
        public void BoxedIntIsDefault()
        {
            Assert.That(IsDefault((object)0), Is.True);
            Assert.That(IsDefault((object)1), Is.False);
            Assert.That(IsDefault<object>(0), Is.True);
            Assert.That(IsDefault<object>(1), Is.False);
        }
        bool IsDefault(object obj)
        {
            return Equals(obj, GetDefault(obj.GetType()));                
        }
        bool IsDefault<T>(T input)
        {
            return Equals(input, GetDefault(input.GetType()));
        }
        public static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
