    public class ParentClass
	{
		public string ShowYourHand()
		{
			var obj = GetExternalObject();
			return obj.ToString();
		}
		protected ExternalObject GetExternalObject()
		{
			return this.RealGetExternalObject();
		}
		protected virtual ExternalObject RealGetExternalObject()
		{
			return new ExternalObject();
		}
	}
	public class ChildClass : ParentClass
	{
		new protected ExternalObjectStub GetExternalObject()
		{
			return (ExternalObjectStub)this.RealGetExternalObject();
		}
		protected override ExternalObject RealGetExternalObject()
		{
			return new ExternalObjectStub();
		}
	}
