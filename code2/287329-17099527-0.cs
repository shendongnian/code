        public enum TVEvent
        {
                Plug,
                SwitchOn,
                SwitchOff,
                Unplug,
                Destroy
        }
        // The TV state value type:
        public enum TVStatus
        {
                Undefined,
                Unplugged,
                Off,
                On,
                Disposed
        }
        // The TV state metadata attribute to annotate the TV state with the definitions of allowed transitions:
        public class TVTransitionAttribute : TransitionAttribute
        {
                public TVStatus From { get; set; }
                public TVEvent When { get; set; }
                public TVStatus Goto { get; set; }
                public string With { get; set; }
        }
        // The TV state proper:
        [TVTransition(From = TVStatus.Unplugged,        When = TVEvent.Destroy,         Goto = TVStatus.Disposed,       With = "TVStateChange")]
        [TVTransition(From = TVStatus.Off,                      When = TVEvent.Destroy,         Goto = TVStatus.Disposed,       With = "TVStateChange")]
        [TVTransition(From = TVStatus.On,                       When = TVEvent.Destroy,         Goto = TVStatus.Disposed,       With = "TVStateChange")]
        [TVTransition(From = TVStatus.Unplugged,        When = TVEvent.Plug,            Goto = TVStatus.Off,            With = "TVStateChange")]
        [TVTransition(From = TVStatus.Off,                      When = TVEvent.SwitchOn,        Goto = TVStatus.On,                     With = "TVStateChange")]
        [TVTransition(From = TVStatus.Off,                      When = TVEvent.Unplug,          Goto = TVStatus.Unplugged,      With = "TVStateChange")]
        [TVTransition(From = TVStatus.On,                       When = TVEvent.SwitchOff,       Goto = TVStatus.Off,            With = "TVStateChange")]
        [TVTransition(From = TVStatus.On,                       When = TVEvent.Unplug,          Goto = TVStatus.Unplugged,      With = "TVStateChange")]
        public class TVState : State<TVStatus, TVEvent, int>
        {
                // The call to (protected) Build() is necessary to build the internal state/transition graph:
                public TVState() : base() { Build(); }
                // This method is called during each allowed transition (BEFORE the state change),
                // and whether or not the from/to states are distinct (sometimes a transition just loops over the same state):
                public static void TVStateChange(IState<TVStatus> state, TVStatus from, TVEvent trigger, TVStatus to, int args)
                {
                        Console.WriteLine("\t\t\tFrom: {0} --- (trigger: {1}({2})) --> To: {3}", from, trigger, args, to);
                }
        }
        // The TV state machine proper:
        public class Television : Machine<TVState, TVStatus, TVEvent, int> { }
        // The TV remote control:
        public class TVRemote : SignalSource<TVEvent, int> { }
        public static class Example
        {
                private static TVEvent[] SampleSimulation1
                {
                        get { return new[] { TVEvent.Plug, TVEvent.Destroy }; }
                }
                private static IEnumerable<TVEvent> SampleSimulation2
                {
                        get
                        {
                                yield return TVEvent.Plug;
                                yield return TVEvent.SwitchOn;
                                yield return TVEvent.Destroy;
                        }
                }
                public static void Run()
                {
                        // The TV's remote control is an ISignalling<Tuple<TVEvent, int>>,
                        // and also an IObservable<Tuple<TVEvent, int>> (see Simulation 4 below):
                        ISignalling<TVEvent, int> remote = new TVRemote();
                        // The TV is in fact an IMachine<TVState, TVStatus, TVEvent, int>,
                        // here shortened to its base type IMachine<TVStatus> for simple enumeration purpose:
                        IMachine<TVStatus> television = new Television();
                        // The state of the TV is in fact an IState<TVStatus, TVEvent, int>,
                        // here shortened to its base type IState<TVStatus> for simple enumeration purpose:
                        IState<TVStatus> state = new TVState();
                        // Enumerating over the IEnumerable<TVEvent> (SampleSimulation1),
                        // which is the source of triggers for state transitions:
                        Console.WriteLine("Simulation 1:");
                        foreach (TVStatus value in state.Using(SampleSimulation1).Start(TVStatus.Unplugged))
                                ;// not interested in doing anything special after each successful transition...
                        // Enumerating over the IEnumerable<TVEvent> (SampleSimulation2),
                        // which is the source of triggers for state transitions:
                        Console.WriteLine("Simulation 2:");
                        foreach (TVStatus value in state.Using(SampleSimulation2).Start(TVStatus.Unplugged))
                                // Just echo the state that we transitioned TO on the console:
                                Console.WriteLine("\t{0}", value);
                        // Anti-pattern:
                        // this coding style does work but isn't recommended:
                        Console.WriteLine("Simulation 3:");
                        if (!state.Start(TVStatus.Unplugged).IsFinal)
                        {
                                Console.WriteLine("\t... Done? {0}", state.IsFinal);
                                if (state.Consume(TVEvent.Plug) && !state.IsFinal)
                                {
                                        Console.WriteLine("\t... Done? {0}", state.IsFinal);
                                        if (state.Consume(TVEvent.SwitchOn) && !state.IsFinal)
                                        {
                                                Console.WriteLine("\t... Done? {0}", state.IsFinal);
                                                if (state.Consume(TVEvent.SwitchOff) && !state.IsFinal)
                                                {
                                                        Console.WriteLine("\t... Done? {0}", state.IsFinal);
                                                        if (state.Consume(TVEvent.Destroy) && !state.IsFinal)
                                                                Console.WriteLine("(not executed)");
                                                        else
                                                                Console.WriteLine("\t... Done? {0}", state.IsFinal);
                                                }
                                        }
                                }
                        }
                        Console.WriteLine("Simulation 4:");
                        // Ensure we are back in the start state:
                        state = television.Using(remote).Start(TVStatus.Unplugged);
                        // Now use the various remote control's Emit signatures:
                        remote.Emit(TVEvent.Plug);
                        remote.Emit(TVEvent.SwitchOn, 1);
                        remote.Emit(new Tuple<TVEvent, int>(TVEvent.SwitchOff, 2));
                        remote.Emit(new KeyValuePair<TVEvent, int>(TVEvent.Unplug, 3));
                        remote.Emit(TVEvent.Destroy, 4);
                }
        }
}
