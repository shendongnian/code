    class Results
    {
      public int Result1 { get; set; }
      public string Result2 { get; set; }
      …
    }
    var actions = new Action<Results>[] { Action1, Action2, … };
   
    Results results = new Results();
    foreach (var action in actions)
      action(results);
