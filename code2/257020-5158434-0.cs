    class Thing
    {
        public virtual void AnnounceSelf()
        {
            Console.WriteLine("I am a Thing.");
        }
    
        public static void AnnounceThing(Thing other)
        {
            Console.WriteLine("Here is a Thing.");
        }
    
        public static void AnnounceThing(OtherThing other)
        {
            Console.WriteLine("Here is ANOTHER type of Thing.");
        }
    }
    
    class OtherThing : Thing
    {
        public override void AnnounceSelf()
        {
            Console.WriteLine("I am ANOTHER Thing.");
        }
    }
    class Program
    {
        public static void Main()
        {
            Thing t = new Thing();
    
            // Outputs "I am a Thing." as expected.
            t.AnnounceSelf();
    
            // Outputs "Here is a Thing." as expected.
            Thing.AnnounceThing(t);
    
            t = new OtherThing();
    
            // This method is virtual, so even though t is typed as Thing,
            // the implementation provided by OtherThing will be called;
            // outputs "I am ANOTHER Thing."
            t.AnnounceSelf();
    
            // In contrast to above, this method will NOT call the more
            // specific overload of AnnounceThing (accepting an OtherThing
            // argument) because t is only typed as Thing, so the compiler
            // will go with the first;
            // outputs "Here is a Thing."
            Thing.AnnounceThing(t);
            // THIS will output "Here is ANOTHER type of Thing."
            Thing.AnnounceThing((OtherThing)t);
        }
    }
