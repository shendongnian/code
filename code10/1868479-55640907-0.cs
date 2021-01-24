    public class ExposeByExplicitIndexer0
    {
        public int Int0 = 1;
        public string String0 = "A";
        public virtual object this[string name]
        {
            get
            {
                switch (name)
                {
                    case "Int0":
                        return this.Int0;
                    case "String0":
                        return this.String0;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (name)
                {
                    case "Int0":
                        this.Int0 = (int)value;
                        break;
                    case "String0":
                        this.String0 = (string)value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }
    }
    public class ExposeByExplicitIndexer1 : ExposeByExplicitIndexer0
    {
        protected Guid _Guid1 = Guid.Empty;
        public Guid Guid1
        {
            get
            {
                return this._Guid1;
            }
            set
            {
                this._Guid1 = value;
            }
        }
        public override object this[string name]
        {
            get
            {
                switch (name)
                {
                    case "Guid1":
                        return this.Guid1;
                    default:
                        return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Guid1":
                        this.Guid1 = (Guid)value;
                        break;
                    default:
                        base[name] = value;
                        break;
                }
            }
        }
    }
    public class ExposeByIndexerUsingReflection0
    {
        public object this[string name]
        {
            get
            {
                FieldInfo fieldInfo;
                if ((fieldInfo = this.GetType().GetField(name)) != null)
                {
                    return fieldInfo.GetValue(this);
                }
                PropertyInfo propertyInfo;
                if ((propertyInfo = this.GetType().GetProperty(name)) != null)
                {
                    return propertyInfo.GetValue(this);
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                FieldInfo fieldInfo;
                if ((fieldInfo = this.GetType().GetField(name)) != null)
                {
                    fieldInfo.SetValue(this, value);
                    return;
                }
                PropertyInfo propertyInfo;
                if ((propertyInfo = this.GetType().GetProperty(name)) != null)
                {
                    propertyInfo.SetValue(this, value);
                    return;
                }
                throw new IndexOutOfRangeException();
            }
        }
    }
    public class ExposeByIndexerUsingReflection1 : ExposeByIndexerUsingReflection0
    {
        public int Int1 = 1;
        public string String1 = "A";
    }
    public class ExposeByIndexerUsingReflection2 : ExposeByIndexerUsingReflection1
    {
        protected Guid _Guid2 = Guid.Empty;
        public Guid Guid2
        {
            get
            {
                return this._Guid2;
            }
            set
            {
                this._Guid2 = value;
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Guid newGuid = Guid.NewGuid();
            Console.WriteLine("Expose by explicit indexer:");
            ExposeByExplicitIndexer1 exposeByExplicitIndexer1 = new ExposeByExplicitIndexer1();
            exposeByExplicitIndexer1["Int0"] = 10;
            exposeByExplicitIndexer1["String0"] = "AAA";
            exposeByExplicitIndexer1["Guid1"] = newGuid;
            Console.WriteLine("output via indexer:");
            Console.WriteLine(exposeByExplicitIndexer1["Int0"]);
            Console.WriteLine(exposeByExplicitIndexer1["String0"]);
            Console.WriteLine(exposeByExplicitIndexer1["Guid1"]);
            Console.WriteLine("output via fields or properties:");
            Console.WriteLine(exposeByExplicitIndexer1.Int0);
            Console.WriteLine(exposeByExplicitIndexer1.String0);
            Console.WriteLine(exposeByExplicitIndexer1.Guid1);
            Console.WriteLine("Expose by indexer using reflection:");
            ExposeByIndexerUsingReflection2 exposeByIndexerUsingReflection2 = new ExposeByIndexerUsingReflection2();
            exposeByIndexerUsingReflection2["Int1"] = 10;
            exposeByIndexerUsingReflection2["String1"] = "AAA";
            exposeByIndexerUsingReflection2["Guid2"] = newGuid;
            Console.WriteLine("output via indexer:");
            Console.WriteLine(exposeByIndexerUsingReflection2["Int1"]);
            Console.WriteLine(exposeByIndexerUsingReflection2["String1"]);
            Console.WriteLine(exposeByIndexerUsingReflection2["Guid2"]);
            Console.WriteLine("output via fields or properties:");
            Console.WriteLine(exposeByIndexerUsingReflection2.Int1);
            Console.WriteLine(exposeByIndexerUsingReflection2.String1);
            Console.WriteLine(exposeByIndexerUsingReflection2.Guid2);
            Console.Read();
        }
    }
