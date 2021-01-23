    public static MemberAccessor<TReturn> GetMemberAccessor<TObj,TReturn>(Expression<Func<TObj, TReturn>> expr, TObj tar) {
        var body = expr.Body;
			
        MemberExpression memberExpression = null;
        if (body is UnaryExpression) {
            var ue = (UnaryExpression)body;
            memberExpression = (MemberExpression)ue.Operand;
        } else if (body is MemberExpression)
            memberExpression = (MemberExpression)body;
        else
            throw new NotImplementedException("can't get MemberExpression");
        String name = memberExpression.Member.Name;
        return new MemberAccessor<TReturn>(tar, name);
    }
    public class MemberAccessor<T> {
        private readonly PropertyDescriptor propertyDesc;
        private readonly Object target;
        public MemberAccessor(Object target, String propertyName) {
            this.target = target;
            this.propertyDesc = TypeDescriptor.GetProperties(target)[propertyName];
        }
        public String Name {
            get { return propertyDesc.Name; }
        }
        public Type Type {
            get { return propertyDesc.PropertyType; }
        }        
        public T Value {
            get { return (T)Convert.ChangeType(propertyDesc.GetValue(target), typeof(T)); }
            set { propertyDesc.SetValue(target, value); }
        }
    }
