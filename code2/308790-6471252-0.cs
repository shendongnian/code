    var enumerator = new List<string> { "A", "B", "C" }.GetEnumerator();
    var lineReader = MockRepository.GenerateStub<ILineReader>();
    
    lineReader.Stub(x => x.CurrentLine())
    	.Return("ignored")
    	.WhenCalled(x => x.ReturnValue = enumerator.Current);
    
    lineReader.Stub(x => x.ReadLine())
    	.Return(false) // will be ignored
    	.WhenCalled(x => x.ReturnValue = enumerator.MoveNext());
