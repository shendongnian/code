        [Test]
        public void RoundTripImmutableTypeAsTuple()
        {
            using(var ms = new MemoryStream())
            {
                var val = new MyValueTypeAsTuple(123, 456);
                Serializer.Serialize(ms, val);
                ms.Position = 0;
                var clone = Serializer.Deserialize<MyValueTypeAsTuple>(ms);
                Assert.AreEqual(123, clone.X);
                Assert.AreEqual(456, clone.Z);
            }
        }
        [Test]
        public void RoundTripImmutableTypeViaFields()
        {
            using (var ms = new MemoryStream())
            {
                var val = new MyValueTypeViaFields(123, 456);
                Serializer.Serialize(ms, val);
                ms.Position = 0;
                var clone = Serializer.Deserialize<MyValueTypeViaFields>(ms);
                Assert.AreEqual(123, clone.X);
                Assert.AreEqual(456, clone.Z);
            }
        }
