     public struct MemberComparison
        {
            public readonly System.Reflection.MemberInfo Member; //Which member this Comparison compares
            public readonly object Value1, Value2;//The values of each object's respective member
            public readonly Exception Value1Exception, Value2Exception;
            public MemberComparison(System.Reflection.MemberInfo member, object value1, object value2, Exception value1Exception = null, Exception value2Exception = null)
            {
                Member = member;
                Value1 = value1;
                Value2 = value2;
                Value1Exception = value1Exception;
                Value2Exception = value2Exception;
            }
            public override string ToString()
            {
                if (Value1Exception != null && Value2Exception != null)
                {
                    if (Value1Exception.GetType().Equals(Value2Exception.GetType()))
                    {
                         return Member.Name + ": Exception in both, same exception type of type "+Value1Exception.GetType().Name+", message in first exception: " +Value1Exception.Message+", message in second exception: "+Value2Exception.Message+", differences in type value: " + string.Join("\n", ReflectiveCompare(Value1Exception, Value2Exception).ToArray());
                    }
                    else if (!Value1Exception.GetType().Equals(Value2Exception.GetType()))
                    {
                        return Member.Name + ": Exception in both, different exception type: " + Value1Exception.GetType().Name + " : " + Value2Exception.GetType().Name+", message in first exception: " +Value1Exception.Message+", message in second exception: "+Value2Exception.Message;
                    }                    
                }
                else if (Value1Exception != null && Value2Exception == null)
                {                    
                       return Member.Name + ": "+ Value2.ToString()+" Exception in first of type " + Value1Exception.GetType().Name+", message is: "+Value1Exception.Message;
                } 
                else if (Value1Exception == null && Value2Exception != null)
                {                    
                       return Member.Name + ": "+ Value1.ToString()+" Exception in second of type " + Value2Exception.GetType().Name+", message is: "+Value2Exception.Message;
                }                
                return Member.Name + ": " + Value1.ToString() + (Value1.Equals(Value2) ? " == " : " != ") + Value2.ToString();
            }
        }
    
        public static bool isCollection(object obj)
        {
            return obj.GetType().GetInterfaces()
        .Any(iface => (iface.GetType() == typeof(ICollection) || iface.GetType() == typeof(IEnumerable) || iface.GetType() == typeof(IList)) || (iface.IsGenericTypeDefinition && (iface.GetGenericTypeDefinition() == typeof(ICollection<>) || iface.GetGenericTypeDefinition() == typeof(IEnumerable<>) || iface.GetGenericTypeDefinition() == typeof(IList<>))));
        }
    //This method can be used to get a list of MemberComparison values that represent the fields and/or properties that differ between the two objects.
    public static List<MemberComparison> ReflectiveCompare<T>(T x, T y)
    {
        List<MemberComparison> list = new List<MemberComparison>();//The list to be returned
        var memb = typeof(T).GetMembers();
        foreach (System.Reflection.MemberInfo m in memb)
            //Only look at fields and properties.
            //This could be changed to include methods, but you'd have to get values to pass to the methods you want to compare
            if (m.MemberType == System.Reflection.MemberTypes.Field)
            {
                System.Reflection.FieldInfo field = (System.Reflection.FieldInfo)m;
                Exception excep1 = null;
                Exception excep2 = null;
                object xValue = null;
                object yValue = null;
                try
                {
                    xValue = field.GetValue(x);
                }
                catch (Exception e)
                {
                    excep1 = e;
                }
                try
                {
                    yValue = field.GetValue(y);
                }
                catch (Exception e)
                {
                    excep2 = e;
                }
                if ((excep1 != null && excep2 == null) || (excep1 == null && excep2 != null)) { list.Add(new MemberComparison(field, yValue, xValue, excep1, excep2)); }
                else if (excep1 != null && excep2 != null && !excep1.GetType().Equals(excep2.GetType())) { list.Add(new MemberComparison(field, yValue, xValue, excep1, excep2)); }
                else if (excep1 != null && excep2 != null && excep1.GetType().Equals(excep2.GetType()) && ReflectiveCompare(excep1, excep2).Count > 0) { list.Add(new MemberComparison(field, yValue, xValue, excep1, excep2)); }
                else if ((xValue == null && yValue == null)) { continue; }
                else if (xValue == null || yValue == null) list.Add(new MemberComparison(field, yValue, xValue));
                else if (!xValue.Equals(yValue) && ((!isCollection(xValue) && !isCollection(yValue)) || (isCollection(xValue) && !isCollection(yValue)) || (!isCollection(xValue) && isCollection(yValue)) || (isCollection(xValue) && isCollection(yValue) && ReflectiveCompare(xValue, yValue).Count > 0)))//Add a new comparison to the list if the value of the member defined on 'x' isn't equal to the value of the member defined on 'y'.
                    list.Add(new MemberComparison(field, yValue, xValue));
            }
            else if (m.MemberType == System.Reflection.MemberTypes.Property)
            {
                var prop = (System.Reflection.PropertyInfo)m;
                if (prop.CanRead && !(prop.GetGetMethod() == null || prop.GetGetMethod().GetParameters() == null) && prop.GetGetMethod().GetParameters().Length == 0)
                {                    
                    Exception excep1 = null;
                    Exception excep2 = null;
                    object xValue = null;
                    object yValue = null;
                    try
                    {
                        xValue = prop.GetValue(x, null);
                    }
                    catch (Exception e)
                    {
                        excep1 = e;
                    }
                    try
                    {
                        yValue = prop.GetValue(y, null);
                    }
                    catch (Exception e)
                    {
                        excep2 = e;
                    }
                    if ((excep1 != null && excep2 == null) || (excep1 == null && excep2 != null)) { list.Add(new MemberComparison(prop, yValue, xValue, excep1, excep2)); }
                    else if (excep1 != null && excep2 != null && !excep1.GetType().Equals(excep2.GetType())) { list.Add(new MemberComparison(prop, yValue, xValue, excep1, excep2)); }
                    else if (excep1 != null && excep2 != null && excep1.GetType().Equals(excep2.GetType()) && ReflectiveCompare(excep1, excep2).Count > 0) { list.Add(new MemberComparison(prop, yValue, xValue, excep1, excep2)); }
                    else if ((xValue == null && yValue == null)) { continue; }
                    else if (xValue == null || yValue == null) list.Add(new MemberComparison(prop, yValue, xValue));
                    else if (!xValue.Equals(yValue) && ((!isCollection(xValue) && !isCollection(yValue)) || (isCollection(xValue) && !isCollection(yValue)) || (!isCollection(xValue) && isCollection(yValue)) || (isCollection(xValue) && isCollection(yValue) && ReflectiveCompare(xValue,yValue).Count > 0)))// || (isCollection(xValue) && isCollection(yValue)  && ((IEnumerable<T>)xValue).OrderBy(i => i).SequenceEqual(xValue.OrderBy(i => i))) )))
                        list.Add(new MemberComparison(prop, xValue, yValue));
                }
                else//Ignore properties that aren't readable or are indexers
                    continue;
            }
        return list;
            }
