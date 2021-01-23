       public interface ICriteria<T>
            where T : IParameter<T>
        {
            string Text { get; set; }
            IList<T> Parameters { get; set; }
        }
