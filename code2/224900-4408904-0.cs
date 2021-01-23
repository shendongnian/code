    private static AnonymousType ProvisionAgent(string name, int department)
            {
                return AnonymousType.Create(new
                {
                    Name = name,
                    Department = department
                });
            }
    
            private List<AnonymousType> CreateAnonAgentList()
            {
                var anonAgents = new List<AnonymousType>();
    
                //  Dave and Cal are in Department 13
                anonAgents.Add(AnonymousType.Create(CreateAgentAnonType("Dan Jacobs", 13, 44)));
                anonAgents.Add(AnonymousType.Create(CreateAgentAnonType("Calvin Jones", 13, 60)));
                
                //  Leasing = Dept 45
                anonAgents.Add(AnonymousType.Create(CreateAgentAnonType("Stanley Schmidt", 45, 36)));
                anonAgents.Add(AnonymousType.Create(CreateAgentAnonType("Jeff Piper", 45, 32)));
                anonAgents.Add(AnonymousType.Create(CreateAgentAnonType("Stewart Blum", 45, 41)));
                anonAgents.Add(AnonymousType.Create(CreateAgentAnonType("Stuart Green", 45, 38)));
    
                //  HR = Dept 21
                anonAgents.Add(AnonymousType.Create(CreateAgentAnonType("Brian Perth", 21, 25)));
                anonAgents.Add(AnonymousType.Create(CreateAgentAnonType("Katherine McDonnel", 21, 23)));
    
                return anonAgents;
            }
