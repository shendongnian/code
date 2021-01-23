    var container = new Container(x =>
    {         
      x.InstanceOf<Rule>().Is.Conditional(o =>
      {                 
        o.If(c => false).ThenIt.Is.OfConcreteType<ARule>();
                       
        o.If(c => true).ThenIt.IsThis(GREEN);
                       
        o.TheDefault.IsThis(RED);
                   
      }).WithName(“conditional”);
    });
