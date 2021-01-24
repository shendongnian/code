c#
static class Helper
{
	 public static void Popup (string xyz ,string abc ,EventHandler eh)
	{
		DependencyService.Get<IPopUp>().Popup(xyz, abc,
	 	 (Color)Application.Current.Resources["PopUpTitleColor"],
	  	 (Color)Application.Current.Resources["PopUpMessageColor"],
	  	 (Color)Application.Current.Resources["PopUpBackgroundColor"],
	  	 (Color)Application.Current.Resources["PopUpSeparatorColor"],
	  	 eh;
	}
}
  
usage 
c#
Helper.Popup("XYZ" , "ABC" , (sen, args) => DidShowFirstMessage = true );
but having an extention method could be a better option here : 
c#
static class Helper
{
     public static void Popup (this IDependencyService ds, string xyz ,string abc ,EventHandler eh)
    {
        ds.Get<IPopUp>().Popup(xyz, abc,
         (Color)Application.Current.Resources["PopUpTitleColor"],
         (Color)Application.Current.Resources["PopUpMessageColor"],
         (Color)Application.Current.Resources["PopUpBackgroundColor"],
         (Color)Application.Current.Resources["PopUpSeparatorColor"],
         eh;
    }
}
usage
c#
DependencyService.Popup("XYZ" , "ABC" , (sen, args) => DidShowFirstMessage = true );
