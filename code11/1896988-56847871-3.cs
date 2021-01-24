    public class RoomState
    {
          [JsonProperty("isActive")]
          public int IsActive { get; set; }
        
          [JsonProperty("questionCount")]
          public int QuestionCount { get; set; }
        
          [JsonProperty("answerTimeOut")]
          public int AnswerTimeOut { get; set; }
        
          [JsonProperty("players")]
          public List<string> Players { get; set; }
    }
