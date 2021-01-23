    [TestFixture]
    public class MemoryUtilsFixture
    {
        [Test]
        public void DeepCopyThrowWhenCopyNonSerializableInstance()
        {
            var nonSerializableInstance = new CustomNonSerializableType();
            Assert.Throws<SerializationException>(() => MemoryUtils.DeepCopy(nonSerializableInstance, true));
        }
            
        [Test]
        public void DeepCopyThrowWhenPassedInNull()
        {
            object instance = null;
            Assert.Throws<ArgumentNullException>(() => MemoryUtils.DeepCopy(instance, true));
        }
            
        [Test]
        public void DeepCopyDoesNotThrowWhenCopyNonSerializableInstanceAndErrorsDisabled()
        {
            var nonSerializableInstance = new CustomNonSerializableType();            
            object result = null;
    
            Assert.DoesNotThrow(() => result = MemoryUtils.DeepCopy(nonSerializableInstance, false));
            Assert.IsNull(result);
        }
    
        [Test]
        public void DeepCopyShouldCreateExactAndIndependentCopyOfAnObject()
        {
            var instance = new CustomSerializableType
                            {
                                DateTimeValueType =
                                    DateTime.Now.AddDays(1).AddMilliseconds(123).AddTicks(123),
                                NumericValueType = 777,
                                StringValueType = Guid.NewGuid().ToString(),
                                ReferenceType =
                                    new CustomSerializableType
                                        {
                                            DateTimeValueType = DateTime.Now,
                                            StringValueType = Guid.NewGuid().ToString()
                                        }
                            };
    
            var deepCopy = MemoryUtils.DeepCopy(instance, true);
                
            Assert.IsNotNull(deepCopy);
            Assert.IsFalse(ReferenceEquals(instance, deepCopy));
            Assert.That(instance.NumericValueType == deepCopy.NumericValueType);
            Assert.That(instance.DateTimeValueType == deepCopy.DateTimeValueType);
            Assert.That(instance.StringValueType == deepCopy.StringValueType);
            Assert.IsFalse(ReferenceEquals(instance.ReferenceType, deepCopy.ReferenceType));
            Assert.That(instance.ReferenceType.DateTimeValueType == deepCopy.ReferenceType.DateTimeValueType);
            Assert.That(instance.ReferenceType.StringValueType == deepCopy.ReferenceType.StringValueType);
        }
    
        [Serializable]
        internal sealed class CustomSerializableType
        {            
            public int NumericValueType { get; set; }
            public string StringValueType { get; set; }
            public DateTime DateTimeValueType { get; set; }
    
            public CustomSerializableType ReferenceType { get; set; }
        }
                    
        public sealed class CustomNonSerializableType
        {            
        }
    }
