    public class MyClass {
        public int Id { get; set; }
        public Lazy<Task<List<Bar>>> Bars { get; private set; }
    
        public MyClass() {
          Bars = new Lazy<Task<List<Bar>>>(() => LoadBars(), true);
        }
    
        private Task<List<Bar>> LoadBars() {
          return Util.Database.GetBarsAsync(Id);
        } 
    
        private async SomethingElseAsync() {
            List<Bar> bars = await Bars.Value;
        }
    }
