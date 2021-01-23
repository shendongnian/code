    class Question {
        ...
        public void SetAnswer(Answer answer) {
            this.AnswersJSON = answer.ToJSONString();
            this.Modified = DateTime.Now;
            this.Modified = User.Identity.Name; // or pass the user into SetAnswer()
        }
    }
    // in your UI code:
    itemView.Question.SetAnswer(itemView.Answer);
