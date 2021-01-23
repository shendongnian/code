    private class ClassC     
    {         
        private IDoSomething _doSomething;          
        public ClassC(IDoSomething doSomething)
        {             
            _doSomething = doSomething;         
        }          
        
        public void SaySomething()          
        {              
            Console.WriteLine("Hello from Class C");               
            //var x = _Kernel.Get<IDoSomething>();               
            _doSomething.SaySomething();          
        }     
    } 
