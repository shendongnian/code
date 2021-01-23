    using System.Collections.Generic;
    using System.Threading;
    class Main {
        Queue<Action> actions = new Queue<Action> ();
        ManualResetEvent the_event = new ManualResetEvent (false);
        public void Invoke (Action action)
        {
            lock (actions) {
                actions.Enqueue (action);
                the_event.Set ();
            }
        }
        public void Poll ()
        {
            Action action = null;
            lock (actions) {
                if (actions.Count > 0) {
                    action = actions.Dequeue ();
                }
            }
            if (action != null)
                action ();
        }
        public void Wait ()
        {
            Action action = null;
            while (true) {
                the_event.WaitOne ();
                lock (actions) {
                    if (actions.Count > 0) {
                        action = actions.Dequeue ();
                    } else {
                        the_event.Reset ();
                    }
                }
                if (action != null)
                    action ();
            }
        }
    }
