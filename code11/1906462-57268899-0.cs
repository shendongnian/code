    IList<Messages> MessagesList = new List<Messages>() {
      new Messages(){ MessagesID = 1, MessagesName="Message 1",QuestionID=1},
      new Messages(){ MessagesID = 2, MessagesName="Message 2",QuestionID=1},
      new Messages(){ MessagesID = 3, MessagesName="Message 3",QuestionID=2}
    };
    // Question collection
    IList<Question> QuestionList = new List<Question>() {
      new Question() { QuestionID = 1, QuestionName = "q1", SectionID = 1,messages = MessagesList.Where(message=> message.QuestionID==1).ToList() } ,
      new Question() { QuestionID = 2, QuestionName = "q2",   SectionID = 1,messages = MessagesList.Where(message=> message.QuestionID==2).ToList() } ,
      new Question() { QuestionID = 3, QuestionName = "q3",  SectionID = 2,messages = MessagesList.Where(message=> message.QuestionID==3).ToList() } ,
      new Question() { QuestionID = 4, QuestionName = "q4" ,  SectionID = 2 ,messages = MessagesList.Where(message=> message.QuestionID==4).ToList()} ,
      new Question() { QuestionID = 5, QuestionName = "q5" ,  SectionID = 2 ,messages = MessagesList.Where(message=> message.QuestionID==5).ToList() }
    };  
    IList<Section> SectionList = new List<Section>() {
      new Section(){ SectionID = 1, SectionName="Section 1",questions = QuestionList.Where(question=> question.SectionID == 1).ToList()},
      new Section(){ SectionID = 2, SectionName="Section 2",questions = QuestionList.Where(question=> question.SectionID == 2).ToList()},
      new Section(){ SectionID = 3, SectionName="Section 3",questions = QuestionList.Where(question=> question.SectionID == 3).ToList()}
    };
    foreach (var section in SectionList)
    {
      Console.WriteLine("Section: " + section.SectionName);
      foreach (var question in section.questions)
      {
         Console.WriteLine("\tQuestion: " + question.QuestionName);
         foreach (var message in question.messages)
         {
            Console.WriteLine("\t\tMessage: " + message.MessagesName);
         }
      }
    }
