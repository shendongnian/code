    public class PropertyAccessFinder : ExpressionVisitor {
        private readonly HashSet<PropertyInfo> _properties = new HashSet<PropertyInfo>();
        
        public IEnumerable<PropertyInfo> Properties {
            get { return _properties; }
        }
        protected override Expression VisitMember(MemberExpression node) {
            var property = node.Member as PropertyInfo;
            if (property != null)
                _properties.Add(property);
            return base.VisitMember(node);
        }
    }
    // Usage:
    var visitor = new PropertyAccessFinder();
    visitor.Visit(predicate);
    foreach(var prop in visitor.Properties)
        Console.WriteLine(prop.Name);
