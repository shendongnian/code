     var QuestionDetails = from Query in doc.Descendants("QuestionDetail")
                           select new Questions
                           {
                                QuestionID = (int)Query.Element("QuestionID"),
                                QuestionType = (string)Query.Element("QuestionType"),
                                Question = (string)Query.Element("Question"),
                                SubQuestionSequence = (string)Query.Element("SubQuestionSequence"),
                                SubQuestion = new SubQuestion() {
                                   Keywords = (string)Query.Element("SubQuestions").Element("Keywords"),
                                   ParentQuestionID = (int)Query.Element("SubQuestions").Element("ParentQuestionID")
                                }
                           };
