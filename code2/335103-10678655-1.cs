    public class MyCommandHandler
    {
        public string Do(MyCommand1 command)
        {
            var myCrmObject = ... ; // load some object
            string message = myCrmObject.CriticalWork(command); // synchronous
            ThreadPool.QueueUserWorkItem(x => myCrmObject.OtherWork(command)); // async
            // async alternative 1
            //Action<MyCommand1> action = myCrmObject.OtherWork; // make into action delegate
            //action.BeginInvoke(null, command); // start action async, no callback
            // async alternative 1a - custom delegate instead of Action. same BeginInvoke call
            // async alternative 2 - Background Worker
            // async alternative 3 - new System.Threading.Thread(...).Start(command);
            return message; // will be here before OtherWork finishes (or maybe even starts)
        }
    }
