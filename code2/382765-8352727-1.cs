       public interface ICriteria<T,S>
            where T : IParameter<S>
        {
            string Text { get; set; }
            IList<T> Parameters { get; set; }
        }
