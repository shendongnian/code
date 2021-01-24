      public static partial class EnumerableExtensions {
        public static IEnumerable<Vertex<T>> BreadthFirstSearch<T>(
          this IEnumerable<T> source, 
          Func<T, IEnumerable<T>> children) {
          if (Object.ReferenceEquals(null, source))
            throw new ArgumentNullException(nameof(source));
          else if (Object.ReferenceEquals(null, children))
            throw new ArgumentNullException(nameof(children));
    
          HashSet<T> proceeded = new HashSet<T>();
    
          Queue<IEnumerable<Vertex<T>>> queue = new Queue<IEnumerable<Vertex<T>>>();
    
          queue.Enqueue(source.Select(item => new Vertex<T>(item)));
    
          while (queue.Count > 0) {
            IEnumerable<Vertex<T>> src = queue.Dequeue();
    
            if (Object.ReferenceEquals(null, src))
              continue;
    
            foreach (var item in src)
              if (proceeded.Add(item.Value)) {
                yield return item;
    
                queue.Enqueue(children(item.Value)
                  .Select(v => new Vertex<T>(v, item, item.Level + 1)));
              }
          }
        }
      }
