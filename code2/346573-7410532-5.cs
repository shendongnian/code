	public class TestModel : ViewModel
	{
		private bool _testProperty;
		public bool TestProperty
		{
			get { return _testProperty; }
			set
			{
				this.SetUndoableValue(v => _testProperty = v, value, _testProperty);
			}
		}
		public bool HasBusinessActionBeenDone { get; set; }
		public void DoBusinessAction()
		{
			this.AddUndo(this.inverseBusinessAction);
			businessAction();
		}
		private void businessAction()
		{
			this.HasBusinessActionBeenDone = true;
		}
		private void inverseBusinessAction()
		{
			this.HasBusinessActionBeenDone = false;
		}
	}
