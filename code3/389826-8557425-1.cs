    public class JobDao : IDisposable {
    
        TNEntities context = new TNEntities();
        
        public Job LoadJob(int id)
        {
           return this.context.Jobs.First(c => c.id == id);
        }
    
        public void Save(){
           this.context.SaveChanges();
        }
        public void Dispose(){
            this.Context.Dispose();
        }
    }
    
