    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Castle.DynamicProxy;
    using System.Reflection;
    using System.ComponentModel;
    
    
    namespace DemoSpace
    {
        public abstract class EntityBase : INotifyPropertyChanged, INotifyPropertyChanging
        {
            public virtual void OnPropertyChanging(string propertyName, object value)
            {
                if ((null != PropertyChanging))
                {
                    PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
                }
            }
    
            public virtual void OnPropertyChanged(string propertyName)
            {
                if ((null != PropertyChanged))
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        
            public event PropertyChangedEventHandler  PropertyChanged;
    
            public event PropertyChangingEventHandler  PropertyChanging;
        }
    
        public class DemoInterceptor<T> : IInterceptor where T : EntityBase
        {
            private T _target;
    
            public DemoInterceptor(T target)
            {
                _target = target;
            }
    
            public void Intercept(IInvocation invocation)
            {
                if (invocation.Method.IsPublic && invocation.Method.Name.StartsWith("set_"))
                {
                    string propertyName = invocation.Method.Name.Substring(4);
                    string privateFieldName = ResolvePropName(propertyName); 
                    
    
                    object original_value = 
                        typeof(T).GetField(privateFieldName, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_target);
                    
                    _target.OnPropertyChanging(propertyName, original_value);
                    invocation.Method.Invoke(_target, invocation.Arguments);
                    _target.OnPropertyChanged(propertyName);
    
                }
                else
                {
                    invocation.ReturnValue = invocation.Method.Invoke(_target, invocation.Arguments);
                }
    
            }
    
            public virtual string ResolvePropName(string propertyName)
            {
                return "_" + propertyName.Substring(0, 1).ToLower() + propertyName.Substring(1);
            }
    
        }
    }
