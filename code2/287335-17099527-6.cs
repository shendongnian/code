    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Test
    {
        using Machines;
    
        public static class WatchingTvSample
        {
            public enum Status { Unplugged, Off, On, Disposed }
    
            public class DeviceTransitionAttribute : TransitionAttribute
            {
                public Status From { get; set; }
                public string When { get; set; }
                public Status Goto { get; set; }
                public object With { get; set; }
            }
    
            // State<Status> is a shortcut for / derived from State<Status, string>,
            // which in turn is a shortcut for / derived from State<Status, string, object> :
            public class Device : State<Status>
            {
                // Executed before and after every state transition :
                protected override void OnChange(ExecutionStep step, Status value, string info, object args)
                {
                    if (step == ExecutionStep.EnterState)
                    {
                        // 'value' is the state value that we have transitioned FROM :
                        Console.WriteLine("\t{0} -- {1} -> {2}", value, info, this);
                    }
                }
    
                public override string ToString() { return Value.ToString(); }
            }
    
            // Since 'Device' has no state graph of its own, define one for derived 'Television' :
            [DeviceTransition(From = Status.Unplugged, When = "Plug", Goto = Status.Off)]
            [DeviceTransition(From = Status.Unplugged, When = "Dispose", Goto = Status.Disposed)]
            [DeviceTransition(From = Status.Off, When = "Switch On", Goto = Status.On)]
            [DeviceTransition(From = Status.Off, When = "Unplug", Goto = Status.Unplugged)]
            [DeviceTransition(From = Status.Off, When = "Dispose", Goto = Status.Disposed)]
            [DeviceTransition(From = Status.On, When = "Switch Off", Goto = Status.Off)]
            [DeviceTransition(From = Status.On, When = "Unplug", Goto = Status.Unplugged)]
            [DeviceTransition(From = Status.On, When = "Dispose", Goto = Status.Disposed)]
            public class Television : Device { }
    
            public static void Run()
            {
                Console.Clear();
    
                // Create a television state machine instance, and return it, set in some start state :
                var tv = new Television().Start(Status.Unplugged);
                bool done;
    
                // Holds iff the chosen start state isn't a final state :
                System.Diagnostics.Debug.Assert(tv != null, "The chosen start state is a final state!");
    
                // Trigger some state transitions with no arguments
                // ('args' is ignored by this state machine's OnChange(...), anyway) :
                done =
                    (
                        tv.
                            MoveNext("Plug").
                            MoveNext("Switch On").
                            MoveNext("Switch Off").
                            MoveNext("Switch On").
                            MoveNext("Switch Off").
                            MoveNext("Unplug").
                            MoveNext("Dispose") // MoveNext(...) returns null iff tv.IsFinal == true
                        == null
                    );
    
                Console.WriteLine();
                Console.WriteLine("Is the TV's state '{0}' a final state? {1}", tv.Value, done);
    
                Console.WriteLine();
                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
        }
    }
