        namespace SabikoBotV2.Services
    {
        public class BotServices : IBotServices
        {
            public BotServices(IConfiguration configuration)
            {
                DispatchService = new LuisRecognizer(new LuisApplication(
                "f2833d51-b9d2-4420xxxxxx",
                "4e17f6cf0574497c85cxxxxxxx",
                $"https://southeastasia.api.cognitive.microsoft.com"),
                new LuisPredictionOptions { IncludeAllIntents = true, IncludeInstanceData = true },
                true);
    
                LuisService = new LuisRecognizer(new LuisApplication(
                "a17b5589-80a4-4245-bfdf-xxxxxx",
                "4e17f6cf0574497c85c260bxxxxxxx",
                $"https://southeastasia.api.cognitive.microsoft.com"),
                new LuisPredictionOptions { IncludeAllIntents = true, IncludeInstanceData = true },
                true);
    
                QnaService = new QnAMaker(new QnAMakerEndpoint
                {
                    KnowledgeBaseId = configuration["QnAKnowledgebaseId"],
                    EndpointKey = configuration["QnAEndpointKey"],
                    Host = configuration["QnAEndpointHostName"]
                });
            }
    
            public LuisRecognizer DispatchService { get; private set; }
            public LuisRecognizer LuisService { get; private set; }
            public QnAMaker QnaService { get; private set; }
        }
    }
