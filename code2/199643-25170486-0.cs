        public static bool ThisMachineIsADomainController()
        {
            Domain domain = Domain.GetCurrentDomain();
            
            string thisMachine = String.Format("{0}.{1}",Environment.MachineName, domain.ToString());
            //Enumerate Domain Controllers
            List<string> allDcs = new List<string>();
            
            foreach (DomainController dc in domain.DomainControllers)
            {
                allDcs.Add(dc.Name);
            }
            return allDcs.Contains(thisMachine);
        }
