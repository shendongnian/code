        public class Source
        {
            public string String{ get; set; }
        }
        public class Target
        {
            public int Int { get; set; }
            public decimal Decimal{ get; set; }
        }
        [Fact]
        public void TestCustomMap()
        {
            Mapper.Initialize(cfg =>
                cfg.CreateMap<Source, Target>()
                    .ForMember(dest => dest.Int, opt => opt.MapFrom(src => src.String))
                    .ForMember(dest => dest.Decimal, opt => opt.MapFrom(src => src.String)));
            var target = Mapper.Instance.Map<Target>(new Source { String = "123" });
            Assert.Equal(expected: 123, actual: target.Int);
            Assert.Equal(expected: 123m, actual: target.Decimal);
            //This will throw an exception
            //Mapper.Instance.Map<Target>(new Source { String = "123.2" });
        }
