`
  static private void DecisionTreeTest()
  {
    Console.WriteLine("Please, answer a few questions with yes or no.");
    Console.WriteLine();
    MakeDecisionTree().Evaluate();
  }
`
`
  static private DTQuery MakeDecisionTree()
  {
    var queryAreYouSure = new DTQuery
    {
      Sentence = "Are you sure?",
      Positive = new DTResult { Sentence = "Buy it." },
      Negative = new DTResult { Sentence = "You need to wait." }
    };
    var queryIsItAGoodBook = new DTQuery
    {
      Sentence = "Is it a good book?",
      Positive = new DTResult { Sentence = "What are you waiting for? Just buy it." },
      Negative = new DTResult { Sentence = "Find another one." }
    };
    var queryDoYouLikeIt = new DTQuery
    {
      Sentence = "Do you like it?",
      Positive = queryAreYouSure,
      Negative = queryIsItAGoodBook
    };
    var queryDoYouWantABook = new DTQuery
    {
      Sentence = "Do you want a book?",
      Positive = queryDoYouLikeIt,
      Negative = new DTResult { Sentence = "Maybe you want a pizza." }
    };
    return queryDoYouWantABook;
  }
}
`
`
abstract public class DTCondition
{
  public string Sentence { get; set; }
  abstract public void Evaluate();
}
`
`
public class DTQuery : DTCondition
{
  public DTCondition Positive { get; set; }
  public DTCondition Negative { get; set; }
  public override void Evaluate()
  {
    Console.WriteLine(Sentence);
    string userInput;
    bool isValid = false;
    do
    {
      userInput = Console.ReadLine();
      if ( userInput.ToLower() == "yes" )
      {
        isValid = true;
        Positive.Evaluate();
      }
      else
      if ( userInput.ToLower() == "no" )
      {
        isValid = true;
        Negative.Evaluate();
      }
      else
        Console.WriteLine("Your answer is not supported, retry please: " +
                          Environment.NewLine + 
                          Sentence);
    }
    while ( !isValid );
  }
}
`
`
public class DTResult : DTCondition
{
  public override void Evaluate()
  {
    Console.WriteLine(Sentence);
  }
}
`
