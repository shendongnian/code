     IEnumerable<Foo> TraverseParents(Foo foo, IEnumerable<Foo> all)
     {
          while(foo != null) 
          {
              foo = (foo.pid == 0) ? null : all.FirstOrDefault(f => f.ID == foo.pid);
              if(foo != null)
              {
                  yield return foo;
              }
          }
     }
     // In the main code
     var id = 10;
     var root = db.Foo.FirstOrDefault(f => f.ID == id);
     var list = TraverseParents(root, db.Foo)
                   .Select(f => f.ID);
