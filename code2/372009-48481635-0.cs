		     [TestFixture]
			class StudyLoaderTest
			{
				[Test]
				public void Test()
				{
					using (var mock = AutoMock.GetLoose())
					{
						// The AutoMock class will inject a mock IStudyLoader
						// into the StudyLoader constructor
						//no need to create/configure a container
						var studyLoader = mock.Create<StudyLoader>();				
						Assert.AreEqual("hi AutoFac Moq", studyLoader.Name);
					}
				}
			}
			 class StudyLoader : IStudyLoader
			{
				public string Name { get; set; } = "hi AutoFac Moq";
			}
			 interface IStudyLoader
			{
				string Name { get; set; }
			}
