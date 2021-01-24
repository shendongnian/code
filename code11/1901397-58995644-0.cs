charp
internal class ControllerBaseCustomization : ICustomization
{
	public void Customize(IFixture fixture)
	{
		fixture.Customizations.Add(
			new FilteringSpecimenBuilder(
				new Postprocessor(
					new MethodInvoker(
						new ModestConstructorQuery()),
					new ControllerBaseFiller()),
				new ControllerBaseSpecification()));
	}
	private class ControllerBaseFiller : ISpecimenCommand
	{
		public void Execute(object specimen, ISpecimenContext context)
		{
			if (specimen == null) throw new ArgumentNullException(nameof(specimen));
			if (context == null) throw new ArgumentNullException(nameof(context));
			if (specimen is ControllerBase controller)
			{
				controller.ControllerContext = new ControllerContext
				{
					HttpContext = (HttpContext)context.Resolve(typeof(HttpContext))
				};
			}
			else
			{
				throw new ArgumentException("The specimen must be an instance of ControllerBase", nameof(specimen));
			}
		}
	}
	private class ControllerBaseSpecification : IRequestSpecification
	{
		public bool IsSatisfiedBy(object request) => request is Type type && typeof(ControllerBase).IsAssignableFrom(type);
	}
}
