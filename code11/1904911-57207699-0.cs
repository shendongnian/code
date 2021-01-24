    using System;
    using System.Linq;
    using System.Reflection;
    
    namespace ObjectMapper
    {
        public class Program
        {
            static void Main(string[] args)
            {
                Source source = new Source();
                source.F1 = 1;
                source.F2 = 2;
                source.F3 = 3;
                source.F4 = 4;
    
                Dest result = new Dest()
                {
                    F1 = source.F1,
                    DestChild1 = 
                         new DestChild1()
                         {
                             F2 = source.F2,
                             F3 = source.F3,
                             DestChild2 = new DestChild2() { F4 = source.F4 }
                         }
                };
    
    
                Dest dest2 = new Dest();
                SetValues(ref source, ref dest2);
    
                Console.WriteLine("Set breakpoint here so you can inspect object");
            }
    
            public static void SetValues<T1,T2>(ref T1 sourceObject, ref T2 destObject)
            {
                PropertyInfo[] pi = sourceObject.GetType().GetProperties();
                //Loop through each sourceObject Property
                foreach (PropertyInfo sourcePI in sourceObject.GetType().GetProperties())
                {
                    //Loop through each destination property to find matching destination property
                    foreach (PropertyInfo destPI in destObject.GetType().GetProperties())
                    {
                        //Within each destination property, look for attribute decorator that says this is the object we want to pair
                        foreach (SourceAttribute sourcePropertyToMatch in destPI.GetCustomAttributes(typeof(SourceAttribute), true).Cast<SourceAttribute>())
                        {
                            //If the source object property we are on matches the attribute decorator of the destination object property, set its value
                            if (String.Compare(sourcePI.Name, sourcePropertyToMatch.Name, true) == 0 || String.Compare(sourcePI.Name, destPI.Name, true)==0)
                            {
                                //Get value from our source object that so we can set it to our destination value
                                object val = sourcePI.GetValue(sourceObject);
    
                                //Avoid null reference exception should we somehow be attempting to assign a null value to a non-nullable type
                                if (val != null)
                                {
                                    destPI.SetValue(destObject, val, null);
                                }
                                break;
                            }
                        }
    
                        //if we get here, there was no source attribute matched. check if it is one of our subobjects and dive into it
                        var destObjectSubObject = destPI.GetValue(destObject);
                        if (destObjectSubObject is DestinationBaseObject)
                        {
                            MethodInfo setValMethodDef = typeof(Program).GetMethod("SetValues");
                            MethodInfo setValMethod = setValMethodDef.MakeGenericMethod(new Type[] { sourceObject.GetType(), destObjectSubObject.GetType() });
                            var parameters = new object[] { sourceObject, destObjectSubObject };
                            setValMethod.Invoke(null, parameters);
    
                            destPI.SetValue(destObject, destObjectSubObject);
                        }
                    }
                }
            }
        }
        
        public class Source
        {
            public int F1 { get; set; }
            public int F2 { get; set; }
            public int F3 { get; set; }
            public int F4 { get; set; }
        }
    
        public abstract class DestinationBaseObject { }
        public class Dest: DestinationBaseObject
        {
            public Dest()
            {
                DestChild1 = new DestChild1();
            }
            [SourceAttribute("F1")]
            public int F1 { get; set; }
            public DestChild1 DestChild1 { get; set; }
        }
    
        public class DestChild1 : DestinationBaseObject
        {
            public DestChild1()
            {
                DestChild2 = new DestChild2();
            }
            [SourceAttribute("F2")]
            public int F2 { get; set; }
            [SourceAttribute("F3")]
            public int F3 { get; set; }
            public DestChild2 DestChild2 { get; set; }
        }
    
        public class DestChild2 : DestinationBaseObject
        {
            [SourceAttribute("F4")]
            public int F4 { get; set; }
        }
        public class SourceAttribute : Attribute
        {
    
            public SourceAttribute(string name)
            {
                Name = name;
            }
            public String Name { get; private set; }
        }
    }
