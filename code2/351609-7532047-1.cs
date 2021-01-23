    class Expense { public int Fixed { get; set; } }
    void Test(int? parameterForCall) {
      Expression<Func<Expense, bool>> predicate = t => t.Fixed == parameterForCall;
      var parameter = (
        (ConstantExpression) (
          (MemberExpression) (
            (BinaryExpression) predicate.Body
          ).Right
        ).Expression
      ).Value;
      var fieldInfo = parameter.GetType().GetFields().First();
      var name = fieldInfo.Name;
      var value = fieldInfo.GetValue(parameter);
      Console.WriteLine(name + " = " + value);
    }
