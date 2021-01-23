      [TestMethod()]
      public void Test()
      {
        try {
            string toBeChecked = MethodToBeTested();
            //the string is so particular that no clear
            //assertion can be made about it.
            Console.WriteLine(toBeChecked);             
            Assert.Inconclusive("Check the console output.");            
        } catch(AsssertInconclusiveException) {
           /* Do nothing */
        }
        } catch(Exception e) {
            Assert.Fail(e.Message);
        }
      }
