    public class Article
    {
        protected virtual ICollection<IComponent> Components { get; set; }
	
        public virtual T Component<T>() where T : IComponent
        {
            return Components.FirstOrDefault(c=>c.Type==typeof(T));
        }
    }
