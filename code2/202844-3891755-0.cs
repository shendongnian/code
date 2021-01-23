    namespace mappertest{
      using AutoMapper;
      using NUnit.Framework;
      [TestFixture]
      public class FooFacts{
        [Test]
        public void MapToFizz(){
          Mapper.Initialize(c=>c.AddProfile(new FooProfile()));
          var foo=new Foo {Bar="BarValue"};
          var fooModel=Mapper.Map<Foo,FooModel>(foo);
          Assert.AreEqual("BarValue",fooModel.Bar);
        }
      }
      public class FooProfile:Profile{
        protected override void Configure(){
          CreateMap<Foo,FooModel>();
        }
      }
      public class Foo{
        public string Bar{get;set;}
        public void Fizz() {}
      }
      public class FooModel{
        public string Bar{get;set;}
        public FizzModel Fizz { get;set;}
      }
      public class FizzModel{}
    }
