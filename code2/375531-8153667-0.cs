    namespace RandomStatesProgram
    {
        class State
        {
            public string Name;
    
            private bool current;
            public bool Current
            {
                get { return current; }
                set
                {
                    if (current)
                    {
                        if (value) StayingHere();
                        else LeavingState();
                    }
                    else
                    {
                        if (value) EnteringState();
                    }
    
                    current = value;
                }
            }
    
            public void StayingHere() { Console.WriteLine("Staying in state " + this.Name); }
            public void EnteringState() { Console.WriteLine("Entering state " + this.Name); }
            public void LeavingState() { Console.WriteLine("Leaving state " + this.Name); }
    
            public State()
            {
                this.Name = "New";
                this.Current = false;
            }
    
            public State(string name)
                : this()
            {
                this.Name = name;
            }
        }
    
        class TransitionCourse
        {
            public State From { get; set; }
            public State To { get; set; }
            public float Probability { get; set; }
    
            public TransitionCourse(Dictionary<int, State> allStates, int fromState, int toState, float probability)
            {
                if (probability < 0 || probability > 1)
                    throw new ArgumentOutOfRangeException("Invalid probability");
    
                if (!allStates.Keys.Any(K => K == fromState || K == toState))
                    throw new ArgumentException("State not found");
    
                this.From = allStates[fromState];
                this.To = allStates[toState];
                this.Probability = probability;
            }
        }
    
        static class States
        {
            private static Dictionary<int, State> PossibleStates;
            public static State Current
            {
                get
                {
                    if (PossibleStates.Where(S => S.Value.Current).Count() == 1)
                        return PossibleStates.Single(S => S.Value.Current).Value;
                    else
                        return null;
                }
            }
    
            public static List<TransitionCourse> Transitions;
    
            static States()
            {
                PossibleStates = new Dictionary<int, State>()
                {
                    {1, new State("One")}, 
                    {2, new State("Two")}, 
                    {3, new State("Three")},
                    {4, new State("Four")} 
                };
    
                // example: 50% chance of switching to either state from every one of the three
                // note: it must be  0 <= 3rd param <= 1 of course (it's a probability)
                Transitions = new List<TransitionCourse>()
                {
                    new TransitionCourse(PossibleStates,1,2,1f/3f),
                    new TransitionCourse(PossibleStates,1,3,1f/3f),
                    new TransitionCourse(PossibleStates,1,4,1f/3f),
                    new TransitionCourse(PossibleStates,2,1,1f),            
                    new TransitionCourse(PossibleStates,3,1,1f),
                    new TransitionCourse(PossibleStates,4,1,1f)               
                };
            }
    
            public static void GoTo(int targetState)
            {
                if (!PossibleStates.Keys.Contains(targetState))
                    throw new ArgumentException("Invalid state");
    
                foreach (KeyValuePair<int, State> state in PossibleStates.OrderByDescending(S=>S.Value.Current))
                {
                    //first is the "true" state (the current one) then the others.
                    //this way we go OUT from a state before going IN another one.
                    state.Value.Current = state.Key.Equals(targetState);
                }
            }
    
            public static void Travel()
            {
                if (Current == null)
                    throw new InvalidOperationException("Current state not set");
    
                TransitionCourse[] exits = Transitions.Where(T => T.From.Equals(Current)).OrderBy(T=>T.Probability).ToArray();
                if (exits.Length == 0) //nowhere to go from here
                    return;
                else
                    if (exits.Length == 1) //not much to choose here
                    {
                        GoTo(PossibleStates.Single(S => S.Value.Equals(exits.First().To)).Key);
                    }
                    else //ok now we have a choice
                    {
                        //we need a "random" number
                        double p = new Random().NextDouble();
    
                        // remapping probabilities so we can choose "randomly"
                        // this works IF the sum of all transitions probability does not exceed 1.
                        // if it does, at best this'll act weird
                        for (int i = 1; i < exits.Length; i++)
                        {
                            exits[i].Probability += exits[i - 1].Probability;
                            if (exits[i].Probability > p)
                            {
                                GoTo(PossibleStates.Single(S => S.Value.Equals(exits[i].To)).Key);
                                return;
                            }
                        }
                    }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                States.GoTo(1);
                while (Console.ReadLine().ToUpper() != "Q")
                {
                    States.Travel();
                }
            }
        }
    }
