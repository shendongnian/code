    public class Foo {
      private static Dictionary<string, Thing> ThingCache = new Dictionary<string, Thing>();
      private Thing myThing;
      public Foo(string name) {
        if (ThingCache.ContainsKey(name)) {
          Init(ThingCache[name]);
        } else {
          Init(ExternalStaticFactory.GetThing(name));
          ThingCache.Add(name, myThing);
        }
      }
      public Foo(Thing tmpThing) {
        Init(tmpThing);
      }
      private void Init(Thing tmpThing) {
        doSomeStuff();
        myThing = tmpThing;
        doSomeOtherStuff();
      }
    }
