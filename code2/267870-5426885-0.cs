    public class Foo
    {
        private static Dictionary<string, Thing> ThingCache = new Dictionary<string, Thing>();
        private Thing myThing;
    
        public Foo(string name)
            : this(null, name)
        {
        }
    
        public Foo(Thing tmpThing)
            : this(tmpThing, null)
        {
        }
    
        public Foo(Thing tmpThing, string name)
        {
            if (tmpThing == null && name == null)
            {
                throw new System.ArgumentException("Either tmpThing or name must be non-null");
            }
    
            doSomeStuff();
            if (tmpThing != null)
            {
                myThing = tmpThing;
            }
            else
            {
                if (ThingCache.ContainsKey(name))
                {
                    myThing = ThingCache[name];
                }
                else
                {
                    myThing = ExternalStaticFactory.GetThing(name);
                    ThingCache.Add(name, myThing);
                }
            }
            doSomeOtherStuff();
        }
    }
