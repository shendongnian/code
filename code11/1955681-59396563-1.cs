    string json = @"{
                               '42f6be79-443b-4845-8549-865af9e74988': {
                                'Active': true,
                                'CompletedMessage': 'Placeholder',
                                'CreatedBy': '',
                                  'Description': 'Placeholder',
                                'DisplayName': 'Placeholder1',
                                'ID': 'be193200-c277-48bd-90ab-796e869f2e0b',
                                'QuestionsIDs': [
                                    'bd341962-6c7f-459d-88ea-86aa7186840a',
                                    'bd341962-6c7f-459d-88ea-86aa7186840a'
                                ],
                                 'WelcomeMessage': 'Placeholder3'
                                }
                            }";
    
                Dictionary<string, Question> questionDictionary = JsonConvert.DeserializeObject<Dictionary<string, Question>>(json);
    
                foreach (Question question in questionDictionary.Values)
                {
                    Guid[] guids = question.QuestionsIDs; // Do whatever you want with it
                }
