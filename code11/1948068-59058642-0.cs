    using Newtonsoft.Json;
    using System;
    using Xunit;
    
    namespace XUnitTestProject1
    {
        public class TimeFormatUnitTest
        {
            [Fact]
            public void ParseCreatedTime()
            {
                var timeString = "2013-01-25T00:11:02+0000";
                var json = "{ \"created_time\": \"" + timeString + "\" }";
    
                var data = JsonConvert.DeserializeObject<FacebookCommentResponseDto>(json);
    
                Assert.Equal(DateTime.Parse(timeString), data.CreatedTime);
            }
        }
    
        public class FacebookCommentResponseDto
        {
            [JsonProperty("created_time")]
            public DateTime CreatedTime { get; set; }
        }
    }
