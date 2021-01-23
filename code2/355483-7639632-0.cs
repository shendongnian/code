    interfate ITask{
       void run();
    }
    abstruct BaseTask : ITask{
       //force "run()" to set Result
       public ResultContainer Result{set;get;}
       void run() {
           Result = runInternal();
       }
       protected abstract ResultContainer runInternal();
    }
    class SomeTask : BaseTask {
       protected override ResultContainer runInternal(){
           return new ResultContainer("task ok");
       }
    }
