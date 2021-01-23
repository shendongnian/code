    public void printNetworkCards()
            {
                PerformanceCounterCategory category = new PerformanceCounterCategory("Network Interface");
                String[] instancename = category.GetInstanceNames();
    
                foreach (string name in instancename)
                {
                    Console.WriteLine(name);
                }
            }
