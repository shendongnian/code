    [TestFixture]
    public class GivenException
    {
       Exception _innerException, _outerException;
    
       [SetUp]
       public void Setup()
       {
          _innerException = new Exception("inner");
          _outerException = new Exception("outer", _innerException);
       }
    
       [Test]
       public void WhenNoInnerExceptions()
       {
          Assert.That(_innerException.SelfAndAllInnerExceptions().Count(), Is.EqualTo(1));
       }
    
       [Test]
       public void WhenOneInnerException()
       {
          Assert.That(_outerException.SelfAndAllInnerExceptions().Count(), Is.EqualTo(2));
       }
    
       [Test]
       public void WhenOneInnerException_CheckComposition()
       {
          var exceptions = _outerException.SelfAndAllInnerExceptions().ToList();
          Assert.That(exceptions[0].InnerException.Message, Is.EqualTo(exceptions[1].Message));
       }
    }
