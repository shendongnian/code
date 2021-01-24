    public class IntroSetupCleanupIteration
        {
            private int rowCount;
            private IEnumrable<object> innerSource;
        
            public IEnumrable<object> Source => this.innerSource; 
            
            [IterationSetup]
            public void IterationSetup(){
                // retreieve data or setup your grid row count for each iteration
               this.InitSource(42);
            }
            
            [GlobalSetup]
            public void GlobalSetup(){
                 // retreieve data or setup your grid row count for every iteration
                 this.InitSource(42);
            }
            
            [Benchmark]
            [ArgumentsSource(nameof(Source))]
            public void ViewPlan(int x)
            {
                //code here
            }
            
            private void InitSource(int rowCount){
                this.innerSource = Enumerable.Range(0,rowCount).Select(t=> (object)t).ToArray(); // you can also shuffle it
            }
                
        }
