	…
	using BundleTransformer.Core.Resolvers;
	…
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			BundleResolver.Current = new CustomBundleResolver();
			…
		}
	}
