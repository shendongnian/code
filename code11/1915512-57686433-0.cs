    namespace someNamespace
    { 
        public class SomeClass
        {
            IEnumerator afterRun()
            {
                yield return new WaitForSeconds(3);            
            }
    
            public void Test(IEnumerator enumerator)
            {
                while(enumerator.MoveNext())
                {
                    //do some work
                }
            }
    
            public void YoureCode()
            {
                Test(afterRun());
            }
        }
    
        public class WaitForSeconds
        {
            public WaitForSeconds(int a)
            {            
            }
        }
    }
