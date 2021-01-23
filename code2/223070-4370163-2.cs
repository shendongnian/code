	private void CallSave(string value)
	{
		_foo.Expect(x => x.Write(Arg.Text.Like(".{512,}")));
		_bar.Save(value);
		_foo.VerifyAllExpectations();
	}
