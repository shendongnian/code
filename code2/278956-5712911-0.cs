    using System;
    using NUnit.Framework;
    using Rhino.Mocks;
    namespace ConsoleApplication1
    {
        public class Tomato
        {
            public Tomato(string t4qpkcsek5h6vgbsy8k4etxdd)
            {
               //
            }
    
            public virtual Movie FindMovieById(int i)
            {
                return null;
            }
        }
    
        public class Movie
        {
            public string Title;
    
            public Movie( )
            {
                
            }
    
            public void FindMovieById(int i)
            {
                throw new NotImplementedException();
            }
        }
    
        [TestFixture]
        public class IndividualMovieTests
        {
            [Test]
            public void Movie_Information_Is_Loaded_Correctly()
            {
                
                //Create Mock.
                Tomato tomato = MockRepository.GenerateStub<Tomato>("t4qpkcsek5h6vgbsy8k4etxdd");
    
                //Put expectations.
                tomato.Expect(t=>t.FindMovieById(0)).IgnoreArguments().Return(new Movie(){Title ="Gone With The Wind"});
    
                //Test logic.
                Movie movie = tomato.FindMovieById(9818);
    
                //Do Assertions.
                Assert.AreEqual("Gone With The Wind", movie.Title);
                
                //Verify expectations.
                tomato.VerifyAllExpectations();
            }
        }
    }
