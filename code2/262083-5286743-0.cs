    public class Thing
    {
        public double ourtime;
        public Action action;
    }
    public class Program
    {
        private readonly Dictionary<string, Thing> delays = new Dictionary<string, Thing>();
        public void Think(float dt)
        {
            timestep = dt * timescale;
            time += timestep;
            var actions = delays.Where(d => time > d.Value.ourtime).Select(d => d.Value.action).ToList();
            actions.ForEach(a => a());
        }
        public void DelayedCall(string id, float delay, Action a)
        {
            delays[id] = new Thing { ourtime = time + delay, action = a };
        }
