c#
public static void Popup(this IPopUp popup, string title, string message, EventHandler handler)
{
    popup.Popup(
        title,
        message, 
        (Color)Application.Current.Resources["PopUpTitleColor"],
        (Color)Application.Current.Resources["PopUpMessageColor"],
        (Color)Application.Current.Resources["PopUpBackgroundColor"],
        (Color)Application.Current.Resources["PopUpSeparatorColor"],   
        handler
    );
}
