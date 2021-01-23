    class Child : Parent {
        public override void DoSomething(IEnumerable<string> list) {
             Console.WriteLine("Child.DoSomething(IEnumerable<string>)");
        }
    
        public void DoSomething(IEnumerable<object> list) {
            if(list is IEnumerable<string>){
                DoSomething((IEnumerable<string>)list);
                return;
            }
            else  
                Console.WriteLine("Child.DoSomething(IEnumerable<object>)");
        }
    }
