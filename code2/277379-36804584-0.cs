    using System;
    using System.Collections.Generic;
    public interface IAnyType { }
    public abstract class PackageBase { }
    public class Class_1 : IAnyType { public string Class_1_String { get; set; } }
    public class Class_2 : IAnyType { public string Class_2_String { get; set; } }
    public class AmmendmentPackage : PackageBase
    {
        public IList<Ammendment<IAnyType>> Ammendments { get; set; }
    }
    public class Ammendment<T> where T : IAnyType
    {
        public T AmmendedElement { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Ammendment<IAnyType> ammendment_1 = new Ammendment<IAnyType>();
            ammendment_1.AmmendedElement = new Class_1();
            Ammendment<IAnyType> ammendment_2 = new Ammendment<IAnyType>();
            ammendment_2.AmmendedElement = new Class_2();
            AmmendmentPackage package = new AmmendmentPackage();
            package.Ammendments = new List<Ammendment<IAnyType>>(2);
            package.Ammendments.Add(ammendment_1);
            package.Ammendments.Add(ammendment_2);
        }
    }
