`
static private void DecisionTreeTest()
{
  Console.WriteLine("Please, answer a few questions with yes or no.");
  Console.WriteLine();
  MakeDecisionTree().Evaluate();
}
`
`
static private bool GetUserAnswer(string question)
{
  Console.WriteLine(question);
  string userInput;
  while ( true )
  {
    userInput = Console.ReadLine().ToLower();
    if ( userInput == "yes" )
      return true;
    else
    if ( userInput == "no" )
      return false;
    else
      Console.WriteLine("Your answer is not supported, retry please." +
                        Environment.NewLine + Environment.NewLine +
                        question);
  }
}
`
`
static private DecisionTreeQuery MakeDecisionTree()
{
  var queryAreYouSure
    = new DecisionTreeQuery("Are you sure?",
                            new DecisionTreeResult("Buy it."),
                            new DecisionTreeResult("You need to wait."),
                            GetUserAnswer);
  var queryIsItAGoodBook
    = new DecisionTreeQuery("Is it a good book?",
                            new DecisionTreeResult("What are you waiting for? Just buy it."),
                            new DecisionTreeResult("Find another one."),
                            GetUserAnswer);
  var queryDoYouLikeIt
    = new DecisionTreeQuery("Do you like it?",
                            queryAreYouSure,
                            queryIsItAGoodBook,
                            GetUserAnswer);
  var queryDoYouWantABook
    = new DecisionTreeQuery("Do you want a book?",
                            queryDoYouLikeIt,
                            new DecisionTreeResult("Maybe you want a pizza."),
                            GetUserAnswer);
  return queryDoYouWantABook;
}
`
`
abstract public class DecisionTreeCondition
{
  protected string Sentence { get; private set; }
  abstract public void Evaluate();
  public DecisionTreeCondition(string sentence)
  {
    Sentence = sentence;
  }
}
`
`
public class DecisionTreeQuery : DecisionTreeCondition
{
  private DecisionTreeCondition Positive;
  private DecisionTreeCondition Negative;
  private Func<string, bool> UserAnswerProvider;
  public override void Evaluate()
  {
    if ( UserAnswerProvider(Sentence) )
      Positive.Evaluate();
    else
      Negative.Evaluate();
  }
  public DecisionTreeQuery(string sentence,
                           DecisionTreeCondition positive,
                           DecisionTreeCondition negative,
                           Func<string, bool> userAnswerProvider)
    : base(sentence)
  {
    Positive = positive;
    Negative = negative;
    UserAnswerProvider = userAnswerProvider;
  }
}
`
`
public class DecisionTreeResult : DecisionTreeCondition
{
  public override void Evaluate()
  {
    Console.WriteLine(Sentence);
  }
  public DecisionTreeResult(string sentence)
    : base(sentence)
  {
  }
}
`
