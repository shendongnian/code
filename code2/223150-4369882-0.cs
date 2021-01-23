      [TestClass]
        public class UnitTest1
        {
            [TestMethod()]
            [DeploymentItem("testFile1.txt")]
            public void ConstructorTest()
            {
                // Create the file to deploy
                Car.CarInfo();
                string file = "testFile1.txt";
                // Check if the created file exists in the deployment directory
                Assert.IsTrue(File.Exists(file), "deployment failed: " + file +
                    " did not get deployed");
            }
        }
