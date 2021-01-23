    [InterfaceSpecification] 
    public class ICanAddTests : AppliesTo<ICanAdd>{ 
    
        [Test] 
        public void can_add_two_numbers() { 
              Assert.AreEqual(5, sut.Add(2,3)); 
        } 
    }
