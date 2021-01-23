    public class Pool{
      private readonly IPickListGenerator _generator;
      private readonly IQuestionIsAnswerableDeterminer _determiner;
      public Pool(IPickListGenerator generator, 
        IQuestionIsAnswerableDeterminer determiner){
        if(determiner==null||generator==null)
          throw new ArgumentNullException();
        _generator=generator;
        _determiner=determiner;
      }
   
      public void Execute(){
        _determiner.Execute();
        _generator.Execute();
      }
    }
