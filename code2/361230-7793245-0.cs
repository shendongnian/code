    class ConditionAction
    {
         public Predicate<string> Condition {get; set; }
         public Action<string> Action {get; set; }
    }
    var conditions = new ConditionAction[]{action1, action2, action3};
    
    foreach (var condition in conditions)
           observable.Where(condition.Condition).Subscribe(condition.Action);
    .....
    observable.Where(s=>!conditions.Any(c=>c.Condition(s))).Subscribe(...);
