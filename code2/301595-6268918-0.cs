    public class FluentMethodInvoker
    {
        Predicate condition = ()=>true;
        Predicate allCondition = null;
        Action method = ()=> {return;};
        bool iterations = 1;
        FluentMethodInvoker previous = null;
    
        public FluentMethodInvoker(){}
        private FluentMethodInvoker(FluentMethodInvoker prevNode)
        { previous = prevNode; }
    
        public FluentMethodInvoker InvokeMethod(Action action)
        {
            method = action;
        }
    
        //Changed "When" to "If"; the function does not wait for the condition to be true
        public FluentMethodInvoker If(Predicate pred)
        {
            condition = pred;
            return this;
        }
    
        public FluentMethodInvoker ForAllIf(Predicate pred)
        {
            allCondition = pred;
            return this;
        }
    
        private bool CheckAllIf()
        {
            return allCondition == null 
                    ? previous == null
                       ? true
                       : previous.CheckAllIf();
                    : allCondition;
        }
    
        public FluentMethodInvoker Repeat(int repetitions)
        {
            iterations = repetitions;
            return this;
        }
    
        //Merging MethodExecuter and MethodExpression, by chaining instances of FluentMethodInvoker
        public FluentMethodInvoker Then()
        {
            return new FluentMethodInvoker(this);
        }
    
        //Here's your trigger
        public void Run()
        {
            //goes backward through the chain to the starting node
            if(previous != null) previous.Run();
    
            if(condition && CheckAllIf())    
               for(var i=0; i<repetitions; i++)
                  method();
    
            return;
        }
    }
    
    //usage
    class Program
    {
        static void Main()
        {
            const bool shouldRun = true;
    
            var invokerChain = new FluentMethodInvoker()
                .ForAllIf(!Context.WannaShutDown)
                    .InvokeMethod(A.Process).Repeat(100)
                    .When(shouldRun)
                .Then().InvokeMethod(B.Process).Repeat(10)
                .ForAllIf(Context.WannaShutDown)
                    .When(shouldRun)
                .Then().InvokeMethod(C.Process);
    
            //to illustrate that the chain doesn't have to execute immediately when being built
            invokerChain.Run();
        }
    }
