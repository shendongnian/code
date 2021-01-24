    public void SerializeAndDeserializeTest()
        {
            var surveyResult = new SurveyResultModel()
            {
                Id = "id",
                SurveyId = "surveyId",
                Steps = new List<ISurveyStepResult>()
                {
                    new BoolStepResult(){ Id = "1", Value = true},
                    new TextStepResult(){ Id = "2", Value = "some text"},
                    new StarsStepResult(){ Id = "3", Value = 5},
                }
            };
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                Converters = { new TypeDiscriminatorConverter<ISurveyStepResult>()},
                WriteIndented = true
            };
            var result = JsonSerializer.Serialize(surveyResult, jsonSerializerOptions);
            var back = JsonSerializer.Deserialize<SurveyResultModel>(result, jsonSerializerOptions);
            var result2 = JsonSerializer.Serialize(back, jsonSerializerOptions);
            
            Assert.IsTrue(back.Steps.Count == 3 
                          && back.Steps.Any(x => x is BoolStepResult)
                          && back.Steps.Any(x => x is TextStepResult)
                          && back.Steps.Any(x => x is StarsStepResult)
                          );
            Assert.AreEqual(result2, result);
        }
