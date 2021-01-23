    class ClassIWantToTestHarness : ClassIWantToTest {
    	public string Arg1 { get; set; }
    	public string Arg2 { get; set; }
        public int CallCount { get; set; }
    	
    	protected override void SomeMethodThatsAPainForUnitTesting(var1, var2) {
    		Arg1 = var1;
    		Arg2 = var2;
                CallCount++;
    	}
    }
    
    [Test]
    public void ClassIWantToTest_DoesWhatItsSupposedToDo() {
    	var harness = new ClassIWantToTestHarness();
    	harness.IWantToTestThisMethod();
    	Assert.AreEqual("Whatever", harness.Arg1);
    	Assert.AreEqual("It should be", harness.Arg2);
        Assert.IsGreaterThan(0, harness.CallCount);
    }
