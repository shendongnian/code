    public class Program
    {
        class A
        {
            public string ProductionDivision { get; set; }
        }
        class B
        {
            private object _productionDivision;
            public enum ProductionDivisionOneofCase
            {
                None = 0,
                IsNullproductionDivision = 15,
                ProductionDivisionValue = 16,
            }
            private ProductionDivisionOneofCase _productionDivisionCase = ProductionDivisionOneofCase.None;
            public bool IsNullProductionDivision
            {
                get { return _productionDivisionCase == ProductionDivisionOneofCase.IsNullproductionDivision ? (bool)_productionDivision : false; }
                set
                {
                    _productionDivision = value;
                    _productionDivisionCase = ProductionDivisionOneofCase.IsNullproductionDivision;
                }
            }
            public string ProductionDivisionValue
            {
                get { return _productionDivisionCase == ProductionDivisionOneofCase.ProductionDivisionValue ? (string)_productionDivision : ""; }
                set
                {
                    _productionDivision = value;
                    _productionDivisionCase = ProductionDivisionOneofCase.ProductionDivisionValue;
                }
            }
        }
       public class StrinToBoolCustomResolver
            : IValueConverter<string, bool>
        {
            public bool Convert(string sourceMember, ResolutionContext context)
            {
                return sourceMember == null;
            }
        }
        public class MyAutoMapperProfile
            : Profile
        {
            public MyAutoMapperProfile()
            {
                // add post and pre prefixes to add corresponding properties in the inner property map
                RecognizeDestinationPostfixes("Value");
                RecognizeDestinationPrefixes("IsNull");
                // add mapping for "value" property
                this.ForAllPropertyMaps(map => map.SourceMember.Name + "Value" == map.DestinationName,
                    (map, expression) =>
                    {
                        expression.Condition((source, dest, sMem, destMem) =>
                        {
                            return sMem != null;
                        });
                        expression.MapFrom(map.SourceMember.Name);
                    });
                // add mapping for "IsNull" property
                this.ForAllPropertyMaps(map => "IsNull" + map.SourceMember.Name == map.DestinationName,
                    (map, expression) =>
                    {
                        expression.Condition((source, dest, sMem, destMem) =>
                        {
                            return (bool)sMem;
                        });
                        //expression.MapFrom(map.SourceMember.Name);
                        expression.ConvertUsing<string, bool>(new StrinToBoolCustomResolver(), map.SourceMember.Name);
                    });
                CreateMap<A, B>();
                   //.ForMember(g => g.IsNullProductionDivision, m =>
                   //{
                   //    m.PreCondition(s => s.ProductionDivision == null);
                   //    m.MapFrom(b => true);
                   //});
                   //.ForMember(g => g.ProductionDivisionValue, m =>
                   //{
                   //    m.PreCondition(s => s.ProductionDivision != null);
                   //    m.MapFrom(b => b.ProductionDivision);
                   //});
            }
        }
        public static void Main(string[] args)
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MyAutoMapperProfile());
            });
            var mapper = new Mapper(configuration);
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
            var a = new A()
            {
                ProductionDivision = null
            };
            var b = mapper.Map<B>(a);
            var c = new A()
            {
                ProductionDivision = "dsd"
            };
            var d = mapper.Map<B>(c);
        }
    }
