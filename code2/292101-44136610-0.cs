    public class Question
    {
        //...
        public int QuestionGridItemID { get; set; }
        public virtual QuestionGridItem GridItem { get; set; }
        //...
        public int? OtherQuestionID { get; set; }
        public Question OtherQuestion { get; set; }
    }
    //...
    question.OtherQuestion = otherQuestion;
    questionGridItem.Questions.Add(question);
    dataContext.SaveChanges(); //fails because otherQuestion wasn't added to 
    //any grid item's Question collection
