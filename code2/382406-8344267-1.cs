     [Test]    
     public void index_returns_view()    
            {    
                 //arrange    
                var mockHttpContext = new Mock<HttpContextBase>();    
                var mockContext = new Mock<ISession>(mockHttpContext.Object);    
                var c = new HomeController(mockContext.Object);    
                //act    
                var v = c.Index() as ViewResult;    
                //assert    
                Assert.AreEqual(v.ViewName, "Index", "Index View name incorrect");    
             } 
