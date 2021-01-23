    BlockingCollection<Action> actions = new BlockingCollection<Action>();
    void main() {
       // start your tasks
       while (true) {
           var action = actions.Take();
           
           action();
       }
    }
    static void t_First(object sender, EventArgs e) {
        string message = "- first callback on:" + Thread.CurrentThread.ManagedThreadId;
        actions.Add(_ => Console.WriteLine(message));
    }
    
