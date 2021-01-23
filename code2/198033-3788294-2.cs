     public void DoSomething() 
     {
      // run the dynamic code
      var s = @"return new Func<string, IList>(s => (from contact in MyNs.MyClass.MyEnumerableVariable where contact.Name == s select contact).ToList());";
      var func = Evaluator.Evaluate(s);
      var result = func("John");
     }
</pre>
