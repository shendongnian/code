 c#
public class AdvancedWebView : HybridWebView
{
...
public void ToggleElementFocus(string elementId, bool onlyUnFocus = true)
        {
            var js = GetJsInvertFocus(elementId, onlyUnFocus);
            InjectJavaScript(js);
            // Logging.Logging.Log(LogType.Information, $"Injected Javascript => {js}");
        }
...
private string GetJsInvertFocus(string elementId, bool onlyUnFocus)
        {
            var builder = new StringBuilder();
            builder.Append($"if (document.getElementById('{elementId}'))");
            builder.Append("{");
            builder.Append($"var element = document.getElementById('{elementId}');");
            builder.Append($"if (element === document.activeElement)");
            builder.Append("{");
            builder.Append($"element.blur();");
            builder.Append("}");
            builder.Append($"else if({onlyUnFocus} == False)");
            builder.Append("{");
            builder.Append($"element.focus();");
            builder.Append("}");
            builder.Append("}");
            return builder.ToString();
        }
...
}
I'm extending the HybridWebview from XLabs, as it already has the functionality to inject JavaScript into the Webview. So that is where i get the InjectJavaScript method from.
On my page in my app, with the Webview, i then have a method that runs, when the element is clicked. To get a click event when clicking the Webview look at this [link][1]. During the method i figure out what the element id is from the event arguments, and then use this id to inject the JavaScript shown above, to unfocus the element, causing the keyboard to not appear at all. Below my OnClicked method can be seen.
 c#
public partial class DentalWebPage : AdvancedTabbedPage
{
...
 private void DentalWebView_OnClicked(object sender, ClickEvent e)
        {
            try
            {
                if (LogUserPosition(sender, e)) return;
                SwapToScanningTap();
            }
            catch (Exception ex)
            {
                Logging.Log(LogType.Exception,
                    ex.GetType().Namespace == typeof(BaseException).Namespace
                        ? $"{ex.GetType()} => {ex}"
                        : $"{ex.GetType()} => {ex.Message}; Stacktrace => {ex.StackTrace}");
            }
        }
private bool LogUserPosition(object sender, ClickEvent e)
        {
            if (Config.DebugMode) Logging.Log(LogType.Debug, $"WebView was clicked...");
            if (Config.DebugMode) Logging.Log(LogType.Debug, $"Element that was clicked is the following one => {e.Element}");
            var success = Enum.TryParse(e.Element.Split(' ')[1].Split('=')[1], out clickedInputId);
            if (!success && !(clickedInputId == InputId.MainContent_TextBoxInputStr ||
                              clickedInputId == InputId.MainContent_TextBoxScanOrder ||
                              clickedInputId == InputId.MainContent_TextBoxSelectProd ||
                              clickedInputId == InputId.MainContent_TextBoxStockReturn))
                return true;
            if (Config.DebugMode && webPageEnding == WebsiteControllers.Stock.ToString().ToLowerInvariant())
                Logging.Log(LogType.Debug, $"WebView was clicked while on the stock page...");
            return false;
        }
private void SwapToScanningTap()
        {
            PerformOnMainThread(() =>
            {
                CurrentPage = Children[1];
                ScanningToggle.IsToggled = true;
                try
                {
                    var isKeyboardShown = services.KeyboardService.IsKeyboardShown;
                    if (Config.DebugMode) Logging.Log(LogType.Debug, $"IsKeyboardShown returns => {isKeyboardShown}");
                    DentalWebView.ToggleElementFocus(clickedInputId.ToString());
                }
                catch (ObjectDisposedException)
                {
                    if (DisposedReattempt) throw;
                    if (Config.DebugMode)
                        Logging.Log(LogType.Debug,
                            $"Input Method has been Disposed; Attempting to reinitialize it and rerun the {nameof(SwapToScanningTap)} method ones again");
                    DisposedReattempt = true;
                    services.KeyboardService.ReInitializeInputMethod();
                    SwapToScanningTap();
                }
            });
        }
...
private void PerformOnMainThread(Action action)
        {
            try
            {
                Device.BeginInvokeOnMainThread(action);
            }
            catch (Exception ex)
            {
                Logging.Log(LogType.Exception,
                    ex.GetType().Namespace == typeof(BaseException).Namespace
                        ? $"{ex.GetType()} => {ex}"
                        : $"{ex.GetType()} => {ex.Message}; Stacktrace => {ex.StackTrace}");
            }
        }
}
If you wish to get a understanding of the format of the string contained in e.Element, then go and look at the link supplied earlier.
Fell free to ask further questions, in case i missed something.
[1]: https://stackoverflow.com/questions/30397090/xamarin-forms-handle-clicked-event-on-webview
