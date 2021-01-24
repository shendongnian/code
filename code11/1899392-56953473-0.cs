        public interface IA
        {
        }
        public interface IAFactory
        {
            IA BuildInstance(string month);
        }
        public class AFactory : IAFactory
        {
            public IA BuildInstance(string month)
            {
                return new A(month);
            }
        }
        
        public class A : IA
        {
            public A(string month)
            {
            }
        }
        public class B
        {
            private readonly IAFactory factory;
            public List<IA> ListOfMonths;
            public B(IAFactory factory)
            {
                this.factory = factory;
                ListOfMonths = new List<IA>();
            }
            public List<IA> SomeMethod()
            {
                string[] months = new[] {"Jan", "Feb", "Mar"};
                foreach (var month in months)
                {
                    var obj = factory.BuildInstance(month);
                    ListOfMonths.Add(obj);
                }
                return ListOfMonths;
            }
        }
