    public class ConcreteComponent1 : IComponent<Contact> {
            internal ConcreteComponent1() {}
            public void PerformTask(object executionContext) 
            {
                  this.contactSource = GetSource(executionContext);
                  foreach(var result in this.contactSource) 
                  {
                        result.Execute(executionContext); 
                  }
            }
            public IEnumerable<Contact> DataSource 
            {
                  get { return this.contactSource; }
                  set { this.contactSource = value; }
            }
       }
