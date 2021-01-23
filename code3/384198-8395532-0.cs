        Runner(Step1, Step2, Step3);
        
        public void Runner<T>(params Func<T>[] stepList)
        {
            foreach (var act in stepList)
            {
                Status(act.Method.Name + "Started");
                var result=act.Invoke();
                Status(act.Method.Name + "Ended", result);  
            }
           
        }
