	[TestMethod]
	public void TestRhino()
	{
		var getBarCount = 0;
		var fi = MockRepository.GenerateStub<IFoo>();
		fi.Stub(x => x.GetBar()).Return("A").WhenCalled(x => getBarCount++);
		Assert.AreEqual("A", fi.GetBar());
		Assert.AreEqual(1, getBarCount);
		// Switch to record to clear behaviour and then back to replay
		fi.BackToRecord(BackToRecordOptions.All);
		fi.Replay();
		getBarCount = 0;
		fi.Stub(x => x.GetBar()).Return("B").WhenCalled(x => getBarCount++);
		Assert.AreEqual("B", fi.GetBar());
		Assert.AreEqual(1, getBarCount);
	}
