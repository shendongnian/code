     [TestMethod]
            public void Does_Application_Display_Correct_Exception_Message_For_Empty_String()
            {
            // Arrange
            var oHelloWorld = new HelloWorld();
            // Act
         
            // Asset
            ExceptionAssert.Throws<ArgumentException>(() => oHelloWorld.GreetingMessge             (""),"Invalid Name, Name can't be empty");
        }
        [TestMethod]
        public void Does_Application_Display_Correct_Exception_Message_For_Null_String()
        {
            // Arrange
            var oHelloWorld = new HelloWorld();
            // Act
            // Asset
            ExceptionAssert.Throws<ArgumentNullException>(() => oHelloWorld.GreetingMessge(null), "Invalid Name, Name can't be null");
        }
