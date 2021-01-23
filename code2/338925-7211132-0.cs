    public class MathProblem : ProblemBase<double>
    {
    }
    var list = new List<IProblem> // better to be a list of the common interface
    {
        new MathProblem(), // now we can add to the list
    };
