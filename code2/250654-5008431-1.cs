    class ActionResultChoiceMap : IEnumerable<ActionResultChoice>
    {
         public void Add(string key, Func<ActionResult> handler);
         public ActionResult Get(string key);
    }
