    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    
    namespace Utils
    {
        public class PropertyComparer<T> : IEqualityComparer<T>
        {
            public bool Equals(T x, T y)
            {
                IEnumerable<PropertyInfo> allProperties = typeof(T).GetProperties();
                foreach(PropertyInfo pi in allProperties)
                {
                    if (pi.GetCustomAttributes<EqualityIrrelevantAttribute>().Any())
                    {
                        continue;
                    }
    
                    object xProp = pi.GetValue(x);
                    object yProp = pi.GetValue(y);
    
                    if ((xProp == null) && (yProp == null))
                    {
                        continue;
                    }
                    else if ((xProp == null) || (yProp == null))
                    {
                        return false;
                    }
                    else if (xProp is ICollection)
                    {
                        if (!CollectionsEqual(xProp as ICollection, yProp as ICollection))
                        {
                            return false;
                        }
                    }
    
                    if (xProp.ToString() != yProp.ToString())
                    {
                        return false;
                    }
                }
    
                return true;
            }
    
            bool CollectionsEqual(ICollection left, ICollection right)
            {
                IEnumerator leftEnumerator = left.GetEnumerator();
                IEnumerator rightEnumerator = right.GetEnumerator();
    
                bool leftAdvanced = leftEnumerator.MoveNext();
                bool rightAdvanced = rightEnumerator.MoveNext();
    
                if ((leftAdvanced && !rightAdvanced) || (rightAdvanced && !leftAdvanced))
                {
                    return false;
                }
                else if (!leftAdvanced && !rightAdvanced)
                {
                    return true;
                }
    
                bool compareByClass = false;
                object comparer = null;
                MethodInfo equalsMethod = null;
    
                // Inspect type first
                object peek = leftEnumerator.Current;
                Type valuesType = peek.GetType();
                if (valuesType.IsClass)
                {
                    compareByClass = true;
                    Type comparerType = typeof(PropertyComparer<>).MakeGenericType(new Type[] { valuesType });
                    equalsMethod = comparerType.GetMethod("Equals", new Type[] { valuesType, valuesType });
                    comparer = Activator.CreateInstance(comparerType);
                }
    
    
                leftEnumerator.Reset();
                rightEnumerator.Reset();
    
                while (true)
                {
                    leftAdvanced = leftEnumerator.MoveNext();
                    rightAdvanced = rightEnumerator.MoveNext();
    
                    if ((leftAdvanced && !rightAdvanced) || (rightAdvanced && !leftAdvanced))
                    {
                        return false;
                    }
                    else if (!leftAdvanced && !rightAdvanced)
                    {
                        return true;
                    }
    
                    object leftValue = leftEnumerator.Current;
                    object rightValue = rightEnumerator.Current;
    
                    if (compareByClass)
                    {
                        bool result = (bool)equalsMethod.Invoke(comparer, new object[] { leftValue, rightValue });
                        if (!result)
                        {
                            return false;
                        }
                    }
                    else if (leftEnumerator.Current.ToString() != rightEnumerator.Current.ToString())
                    {
                        return false;
                    }
    
                    // Continue looping
                }
            }
    
            public int GetHashCode(T obj)
            {
                throw new NotImplementedException();
            }
        }
    }
