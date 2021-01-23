         public class Bindable : Attribute
            {
                public bool IsBindable { get; set; }
            }
        
            public class Person
            {
                [Bindable(IsBindable = true)]
                public string FirstName { get; set; }
        
                [Bindable(IsBindable = false)]
                public string LastName { get; set; }
            }
        
            public class Test
            {
                public void Bind()
                {
                    Person p = new Person();
        
                    foreach (PropertyInfo property in p.GetType().GetProperties())
                    {
                    
                       try
                       {
                           Bindable _Attribute = (Bindable)property.GetCustomAttributes(typeof(Bindable), false).First();
        
                           if (_Attribute.IsBindable)
                           {
                                //TODO
                           }
                        }
                        catch (Exception) { }
                    }
                }
            }
