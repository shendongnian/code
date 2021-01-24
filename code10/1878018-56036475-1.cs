    public class DbContextFactory {
        
        private readonly TodoContext todoContext;
        private readonly OtherContext otherContext;
        
        // Uses dependency injection
        public DbContextFactory(TodoContext todoContext, OtherContext otherContext) {
            this.todoContext = todoContext;
            this.otherContext = otherContext;
        }
        
        // maybe its better to use a custom Repository Interface here as return type that has a "FetchAll" method
        public DBContext Get(string parameter) {
        	switch(parameter) {
                case "todo":
                    return this.todoContext;
               break;
               ...
            }
        }
    }
