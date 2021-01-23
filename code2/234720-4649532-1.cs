    var container = new Container(x =>
    {         
      x.InstanceOf<IDateAdjuster>().Is.Conditional(o =>
      {                 
        o.If(c => c.GetInstance<IUserSettings>()
         .UseTestDateAdjuster).ThenIt.Is.OfConcreteType<DateAdjusterForTest>();
                       
        o.TheDefault.Is.OfConcreteType<DateAdjuster>();
      });
    });
