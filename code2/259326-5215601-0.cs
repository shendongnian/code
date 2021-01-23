    var stubSet = MockRepository.GenerateStub<IObjectSet<Project>>();
    stubSet.Stub(s => s.Projects).Return(new[]
			                                     	{
			                                     		new Project {Categories = null},
			                                     		new Project {Categories = "abc"}
			                                     	});
