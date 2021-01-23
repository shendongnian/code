    public class MyController{
        private readonly IClass1 _class1;
        public MyController(IClass1 class1){
            _class1 = class1;
        }
        // Other code uses this private instance
    }
    [TestMethod]
    public void Test(){
        var class1 = new Mock<Class1>();
        var controller = new MyController(class1.Object);
    }
