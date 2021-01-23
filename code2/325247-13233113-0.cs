	[TestMethod]
	public void TestViewModel3()
	{
		int min = -10;
		int max = 10000;
		int initVal = 50;
		bool initState = false;
		ToglledSliderModel model = new ToglledSliderModel(initState, initVal, min, max);
		ToglledSliderViewModel viewModel = new ToglledSliderViewModel();
		viewModel.Model = model;
		int status = 567;
		viewModel.PropertyChanged += delegate
		{
			status = 234;
		};
		for (int i = 1; i < 100; i++)
		{
			status = 567;
			ICommand ic = viewModel.IncreaseValue;
			ic.Execute(this);
			Thread.Sleep(2);
			Assert.AreEqual(status, 234);
			Assert.AreEqual(model.SliderValue, initVal + i);
		}
	}
