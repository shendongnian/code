        [Fact]
        public void GetTimeZoneNameByOffsetTime_ShouldParseTimeZoneNameFromOffsetTime()
        {
            //Arrange
            var expected = "Central America Standard Time";
            //Act
            var allTimeZones = TimeZoneInfo.GetSystemTimeZones();
            var newTimeZone = allTimeZones.FirstOrDefault(x => x.BaseUtcOffset == new TimeSpan(-6, 0, 0));
            var actual = newTimeZone.StandardName;
            //Assert
            actual.ShouldBe(expected);
        }
		
