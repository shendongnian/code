    public class CustomResolver :
        IValueResolver<
            (ObjectA Item, IEnumerable<ObjectA> List),
            ViewModelA,
            String
            >
    {
        public string Resolve(
            (ObjectA Item, IEnumerable<ObjectA> List) source,
            ViewModelA destination, 
            string destMember, 
            ResolutionContext context
            )
        {
            /* Retrieve something via the list. */
            var suffix = source.List.Count().ToString(); 
            return $"{source.Item.Name} {suffix}";
        }
    }
