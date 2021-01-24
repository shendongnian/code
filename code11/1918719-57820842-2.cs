    public class Population
    {
        private List<Chromosome> population;
    
        public Population(int sizePopulation)
        {
            population = new List<Chromosome>(sizePopulation);
        }
        public void Add(Chromosome chromosome)
        {
            population.Add(chromosome);
        }
        public Chromosome Higher()
        {
            return population.OrderBy(chr => chr.Fitness).Last();
        }
     }
