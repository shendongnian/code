    using System;
    using AutoMapper;
    
    public class Source
    {
        public int RecordId { get; set; }
        public string Foo { get; set; }
        public string Bar { get; set; }
    }
    
    public class Target
    {
        public Target(int recordid)
        {
            RecordId = recordid;
        }
    
        public int RecordId { get; set; }
        public string Foo { get; set; }
        public string Bar { get; set; }
    }
    
    
    class Program
    {
        static void Main()
        {
            Mapper
                .CreateMap<Source, Target>()
                .ConstructUsing(source => new Target(source.RecordId));
            var src = new Source
            {
                RecordId = 5,
                Foo = "foo",
                Bar = "bar"
            };
            var dest = Mapper.Map<Source, Target>(src);
            Console.WriteLine(dest.RecordId);
            Console.WriteLine(dest.Foo);
            Console.WriteLine(dest.Bar);
        }
    }
