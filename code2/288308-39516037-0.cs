    static object DeepCopy(object obj, Type targetType)
        {
            if (obj != null)
            {
                Type t = obj.GetType();
                object objCopy = Activator.CreateInstance(targetType);
                Type copyType = targetType;
                var props =
                    t.GetProperties();
                        //.Where(x => x.PropertyType.GetCustomAttributes(typeof(XmlIgnoreAttribute), false).Length == 0);
                foreach (var propertyInfo in props)
                {
                    var targetProperty = copyType.GetProperties().Where(x => x.Name == propertyInfo.Name).First();
                    if (targetProperty.GetCustomAttributes(typeof(XmlIgnoreAttribute), false).Length > 0)
                    {
                        continue;
                    }
                    if (propertyInfo.PropertyType.IsClass)
                    {
                        if (propertyInfo.PropertyType.GetInterface("IList", true)!=null)
                        {
                            var list = (IList)Activator.CreateInstance(targetProperty.PropertyType);
                            targetProperty.SetValue(objCopy,list);
                            var sourceList = propertyInfo.GetValue(obj) as IList;
                            foreach (var o in sourceList)
                            {
                                list.Add(DeepCopy(o, targetProperty.PropertyType.UnderlyingSystemType.GenericTypeArguments[0]));
                            }
                        }
                        else if (propertyInfo.PropertyType == typeof(string))
                        {
                            targetProperty.SetValue(objCopy, propertyInfo.GetValue(obj));
                        }
                        else
                        {
                            targetProperty.SetValue(objCopy, DeepCopy(propertyInfo.GetValue(obj), targetProperty.PropertyType));
                        }
                        
                    }
                    else
                    {
                        targetProperty.SetValue(objCopy,propertyInfo.GetValue(obj));
                    }
                }
                return objCopy;
            }
            return null;
        }
        class MyDbContext:DbContext
    {
        public MyDbContext():base(@"Server=(LocalDb)\v12.0;Trusted_Connection=True;")
        {
            
        }
        public DbSet<Table1> Table1s { get; set; }
        public DbSet<Table2> Table2s { get; set; }
    }
    public class Table1
    {
        public int ID { get; set; }
        public string name { get; set; }
        
        virtual public List<Table2> Table2s { get; set; }
    }
    public class Table2
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [XmlIgnore]
        virtual public Table1 Table1 { get; set; }
    }
