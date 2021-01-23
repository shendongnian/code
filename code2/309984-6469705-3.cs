       [TestClass()]
        public class UserTest
        {
    
            /// <summary>
            /// If the email is valid it is stored in the private container
            /// </summary>
            [TestMethod()]
            public void UserEmailGetsValidated()
            {
                User x = new User();
                x.Email = "test@test.com";
                Assert.AreEqual("test@test.com", x.Email);
            }
    
            /// <summary>
            /// If the email is invalid it is not stored and an error is thrown in this application
            /// </summary>
            [TestMethod()]
            [ExpectedException(typeof(NotSupportedException))]
            public void UserEmailPropertyThrowsErrorWhenInvalidEmail()    
           {
               User x = new User();
               x.Email = "bla bla bla";
               Assert.AreNotEqual("bla bla bla", x.Email);
           }
    
    
            /// <summary>
            /// Clears an assumption that on object creation the email is validated when its set
            /// </summary>
            [TestMethod()]
            public void UserGetsValidatedOnConstructionOfObject()
            {
                User x = new User() { Email = "test@test.com" };
                x.Email = "test@test.com";
                Assert.AreEqual("test@test.com", x.Email);
            }
        }
