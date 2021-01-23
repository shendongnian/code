       class UserThingC : IThing
       {
          public void Accept(SystemVisitor visitor)
          {
             var userVisitor = visitor as UserVisitor;
             if (userVisitor == null) throw new ArgumentException("visitor");
             userVisitor.Visit(this);
          }
       }
