    [TestClass]
    public class EnumJsonConverterTest {
        [TestMethod]
        public void Should_Parse_AgencyType_Enum() {
            var json = @"{ ""AgencyType1"": ""Drug & Alcohol"", ""AgencyType2"": ""Corrections"" }";
            var actual = JsonConvert.DeserializeObject<Agency>(json);
            actual.Should().NotBeNull();
            actual.AgencyType1.Should().Be(AgencyTypes.DrugAndAlcohol);
            actual.AgencyType2.Should().Be(AgencyTypes.Corrections);
        }
    }
    public class Agency {
        public AgencyTypes AgencyType1 { get; set; }
        public AgencyTypes AgencyType2 { get; set; }
        //...
    }
