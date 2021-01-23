    struct particle
        {
            public double[] position = new double[100];
            public double Gbest, Lbest;
            public double Pconst = 0.5;
        }
    
         particle[] swarm = new particle[swarm_size];
             for (int i = 0; i < swarm_size; i++)
               {
                swarm[i] = new particle();
               }
    
        foreach(particle p in swarm)
        {
           // do magic here
        }
