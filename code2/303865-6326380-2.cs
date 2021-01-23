     public class Synchro
        {
            public void Start(List<someClass> collection)
            {
                new Thread(()=>Method3(collection));
            }
            public void Method1(someClass)
            {
                //Do some work.               
            }
            public void Method2(someClass)
            {
                //Do some other work.                
            }
            public void Method3(List<someClass> collection)
            {
                //Do your work on each item in Parrallel threads.
                Parallel.ForEach(collection, x => { Method1(x); Method2(x); });
                //Do some work on the total collection like sorting or whatever.                
            }
        }
    
