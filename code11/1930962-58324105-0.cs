 public void ShouldSatisfyAllConditions(params Action[] assertions)
 {
       foreach (var assertion in assertions)
       {
           assertion?.Invoke();
       }
 }
