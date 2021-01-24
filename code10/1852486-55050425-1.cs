    public class MySettings
    {
        [JsonProperty("PostProcessing")]
        public SomeNameElseSettings SomenameElse { get; set; }
        public class SomeNameElseSettings
        {
            [JsonProperty("ValidationHandlerConfiguration")]
            public ValidationHandlerConfigurationSettings WhateverNameYouWant { get; set; }
            public class ValidationHandlerConfigurationSettings
            {
                [JsonProperty("MinimumTrustLevel")]
                public int MinimumTrustLevelFoo { get; set; }
                [JsonProperty("MinimumMatchingTrustLevel")]
                public int MinimumMatchingTrustLevelBar { get; set; }
            }
        }
    }
