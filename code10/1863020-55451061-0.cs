    class SwappedList<T> : IList<IList<T>>,
          // Only if desired; most functions will be one lined calls to IList<IList<T>>
          IReadOnlyList<IReadOnlyList<T>>
          ICollection<ICollection<T>>,
          IReadOnlyCollection<IReadOnlyCollection<T>>
          IEnumerable<IEnumerable<T>>
    {
        public IList<IList<T>> Source {get; set;}
        ... // TODO: implement
    }
