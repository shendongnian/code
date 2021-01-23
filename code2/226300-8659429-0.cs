        public TestContext TestContext { get; set; }
        [TestMethod]
        public void Proper_Permissions_Set_In_app_manifest()
        {
            // Arrange
            var expected = "requireAdministrator";
            using (StreamReader reader = new StreamReader(Path.Combine(TestContext.TestDeploymentDir, "app.manifest")))
            {
                var doc = XDocument.Load(reader.BaseStream);
                var node = doc.Descendants("{urn:schemas-microsoft-com:asm.v3}requestedExecutionLevel").First();
                var attribute = node.Attribute("level");
                // Act
                var actual = attribute.Value;
                // Assert
                Assert.AreEqual(expected, actual);
            }
        }
