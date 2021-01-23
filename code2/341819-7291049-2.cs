     IEnumerable<Foo> TraverseParents(Foo foo, IEnumerable<Foo> all)
     {
          while(foo != null) 
          {
              yield return foo;
              foo = (foo.pid == 0) ? null : all.FirstOrDefault(f => f.ID == foo.pid);
          }
     }
     // In the calling code
     var id = 10;
     Foo root = db.Foo.FirstOrDefault(f => f.ID == id);
     List<int> list = TraverseParents(root, db.Foo)
                       .Select(f => f.ID)
                       .ToList();
