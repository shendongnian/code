     public void DoSomething() 
     {
      // run the dynamic code
      var s = @"return new Func&lt;string, IQueryable&lt;MyNs.Model.Contact&gt;, IList&gt;((s,q) => (from contact in q where contact.Name == s select contact).ToList());";
      var func = Evaluator.Evaluate(s);
      var result = func("John");
     }
</pre>
