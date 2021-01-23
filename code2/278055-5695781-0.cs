    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using Newtonsoft.Json;
    
    namespace JsonNET
    {
        [TestFixture]
        public class JsonNetExamples
        {
            class ReleaseDateCollection
            {
                [JsonProperty(PropertyName = "release_dates")]
                public Dictionary<string, DateTime> ReleaseDates { get; set; }
            }
    
            [Test]
            public void DerializeReleaseDateCollection()
            {
                const string json = @"{""release_dates"":{""theater"": ""1939-12-15"",""dvd"": ""2000-03-07"",""bluray"": ""1977-05-25""}}";
                var collection = JsonConvert.DeserializeObject<ReleaseDateCollection>(json);
                Assert.AreEqual(new DateTime(1939, 12, 15), collection.ReleaseDates["theater"]);
                Assert.AreEqual(new DateTime(2000, 3, 7), collection.ReleaseDates["dvd"]);
                Assert.AreEqual(new DateTime(1977, 5, 25), collection.ReleaseDates["bluray"]);
            }
        }
    }
