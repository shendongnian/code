    public class UnitTest
    {   
         Mock<IDbAccess> _db ;   
         MyProblematicClass _mpc;   
         StringCollection errors;
         pubic Setup()   
         {       
              _db.Setup(x=>x.Save(It.IsAny<Item>).Returns(u =>MyDbExtension.Save(u));
              _db.Setup(x=>x.Errors).Returns(errors);      
              _mpc = new MyProblematicClass(_db.Object);   
         } 
         public void SetItem_EmptyObject_ContainsError() 
         {    
              errors.Add("Expected Error!");
              Item i = new Item();    
              _mpc.SetItem(i);    
              
              Assert.AreEqual("Expected Error!", _mpc.Errors[0]);
         }
     }
