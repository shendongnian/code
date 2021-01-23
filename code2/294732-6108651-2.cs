     partial class Scientist
     {
         public IEnumerable<QuestionArgs> FindQuestions(Predicate<QuestionArgs> interest, IPresident asker)
         {
             return this.Questions.Where( x => interest(x) == true && x.IsAuthorizedToAsk(asker))
         }
     }
     // ...
    partial class President
    {
        FirePhysicists()
        {
            foreach(var scientist in scientists)
            {
                 if(scientist.FindQuestions(x => x.Catagory == QuestionCatagory.Physics, this).Count != 0)
                 {
                     scientist.Fire();
                 }
             }
          }
     }
