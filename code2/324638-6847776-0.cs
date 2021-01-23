    public class Particle
    {
        private readonly double[] positions = new double[100];
        // TODO: Rename these to something useful
        public double Gbest { get; private set; }
        private double Lbest;
        private double Pconst = 0.5;
        public Particle(int g)
        {
            Gbest = g; // Or whatever
        }
    }
    
    List<Particle> swarm = new List<Particle>();
    for (int i = 0; i < swarmSize; i++)
    {
        swarm.Add(new Particle(i));
    }
    double total = 0;
    foreach (Particle particle in swarm)
    {
        total += particle.Gbest;
    }
