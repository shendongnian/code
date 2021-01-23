    public class MyThingFactory
    {
        IThing CreateThing(Speed speed)
        {
            if(speed == Speed.Fast)
            {
                return new FastThing();
            }
    
            return new SlowThing();
        }
    }
