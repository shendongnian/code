     [Test]
     public void InitializeContext()
     {
         using (HttpSimulator simulator = new HttpSimulator())
         {
            //Test #1...
         }
     }
    [Test]
    public void Simulator_Assigns_CurrentContext()
    {
        using (HttpSimulator simulator = new HttpSimulator())
        {
            //Test #2...
        }
    }
