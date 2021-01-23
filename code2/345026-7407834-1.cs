            var workflow = new Sequence();
            //Variable<string> v = new Variable<string>
            //{
            //    Name = "str" 
            //};
            //workflow.Variables.Add(v);
            Dictionary<string, object> abc = new Dictionary<string, object>();
            abc.Add("thedata", "myValue");
            foreach (MyCustomActivity activity in mAddedActivities)
            {
                if (activity.ActivityResult == null)
                    activity.ActivityResult = new Dictionary<string, object>();
                activity.ActivityResult = abc;                
                workflow.Activities.Add(activity);
                //new Assign<string>
                //           {
                //               To = v,
                //               Value = activity.ActivityResult["thedata"].ToString()
                //           };                
                      
            }
            WorkflowInvoker invoker = new WorkflowInvoker(workflow);
            invoker.Invoke();
