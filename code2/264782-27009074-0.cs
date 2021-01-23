        [Test]
        public void Test_the_State_value_IsRequired()
        {
            string value = "Finished";
            var propertyInfo = typeof(TimeoffTemporalIncapacityEntry).GetProperty("State");
            var attribute = propertyInfo.GetCustomAttributes(typeof(RequiredAttribute), true).Cast<RequiredAttribute>().FirstOrDefault();
            Assert.IsTrue(attribute.IsValid(value));
        }
