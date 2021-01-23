    class Expense { public int Fixed { get; set; } }
    void Test(int? parameterForCall) {
      Expression<Func<Expense, bool>> predicate = t => t.Fixed == parameterForCall;
      dynamic value = (
        (ConstantExpression) (
          (MemberExpression) (
            (BinaryExpression) predicate.Body
          ).Right
        ).Expression
      ).Value;
      int? parameter = value.parameterForCall;
      Console.WriteLine(parameter);
    }
