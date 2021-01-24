            [DebuggerDisplay("Id:{Id} | Type:{Type} | Act:{Act}")] // format properties as you like
            public class TypeContainer
            {
                public int Id { get; set; }
    
                public int Type { get; set; }
    
                public int Act { get; set; }
            }
    
            [DebuggerDisplay("{DebuggerDisplay,nq}")]
            [DebuggerTypeProxy(typeof(FakeNeuronDebugView))] // specify a proxy 
            public class MyFakeNeuron
            {
    
                public MyFakeNeuron()
                {
                    this.Neurons = new int[10, 10];
                }
    
                public int[,] Neurons { get; set; }
    
                private string DebuggerDisplay => "Count = " + this.Neurons.Length;
    
                private class FakeNeuronDebugView
                {
                    private readonly MyFakeNeuron myFakeNeuron;
                    public FakeNeuronDebugView(MyFakeNeuron myFakeNeuron)
                    {
                        this.myFakeNeuron = myFakeNeuron;
                    }
    
                    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
                    public TypeContainer[] Values
                    {
                        get
                        {
                            var keys = new List<TypeContainer>();
                            var source = this.myFakeNeuron.Neurons;
                            for (int j = 0; j < source.GetLength(0); j++)
                            {
                                var key = new TypeContainer
                                {
                                    Id = source[0, j],
                                    Type = source[1, j],
                                    Act = source[2, j],
                                };
                                keys.Add(key);
                            }
    
                            return keys.ToArray();
                        }
                    }
                }
            }
