    public static T Set<T,TProp>(this T o,
       Expression<Func<T,TProp>> field,TProp value){
      var fn=((MemberExpression)field.Body).Member.Name;
      o.GetType().GetProperty(fn).SetValue(o,value,null);
      return o;
    }
