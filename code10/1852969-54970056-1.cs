    public class MyClass
    {
       public virtual bool isEven(int x) {
             return (x % 2 == 0);
           }
       public bool OtherMethod() {
           return !isEven();
       }
    }
    Mock<MyClass> myMock = new Mock<MyClass>();
    myMock.CallBase = true;
    myMock.Setup(x => x.isEven(It.Any<int>())).Returns(true);
    
    var result = myMock.Object.OtherMethod();
    
