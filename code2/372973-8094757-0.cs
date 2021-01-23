        public class MyModel
        {
            public class ImpressionInfo //just used to store your results sub class of the model
            {
                public ImpressionInfo(id, impression, diaryImpressionCount)
                {
                    Id = id;
                    Impression = impression;
                    DiaryImpressionCount = diaryImpressionCount
                }
            
                public int Id { get; set; }
                public int Impression { get; set; } //is this an int? you didn't say
                public int DiaryImpressionCount { get; set; }
            }
            public MyModel()
            {
                var impressionInfo = new List<ImpressionInfo>()
        
                foreach (var di in dbContext.DiaryImpressions)
                {
                    ImpressionInfos.Add(new ImpressionInfo(
                        di.Id,
                        di.Impression,
                        dbContext.DiaryPosts
                            .Count(dp => dp.ImpressionsId == di.ID));
                }
            }
            public List<ImpressionInfo> ImpressionInfos { get; set; }
