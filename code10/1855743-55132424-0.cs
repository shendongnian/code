    public class LocalizedTabPresenter : MvxAppCompatViewPresenter
    {
    	public LocalizedTabPresenter(IEnumerable<Assembly> androidViewAssemblies) : base(androidViewAssemblies)
    	{
    	}
    
    	protected override Task<bool> ShowViewPagerFragment(Type view, MvxViewPagerFragmentPresentationAttribute attribute, MvxViewModelRequest request)
    	{
    		if (attribute.ViewModelType == typeof(Tab1ViewModel)) { 
    			attribute.Title = "My Localized Title for Tab 1"
    		}
    
    		return base.ShowViewPagerFragment(view, attribute, request);
    	}
    }
