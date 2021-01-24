    [ControlDefinition("iframe", ContainingClass = "cke_wysiwyg_frame", ComponentTypeName = "CKEditor")]
    public class CKEditor<TOwner> : EditableField<string, TOwner>
        where TOwner : PageObject<TOwner>
    {
        protected override string GetValue()
        {
            string value = null;
    
            DoWithinFrame(body =>
            {
                value = body.Text;
            });
    
            return value;
        }
    
        protected override void SetValue(string value)
        {
            DoWithinFrame(body =>
            {
                body.Clear();
                body.SendKeys(value);
            });
        }
    
        // An appoach to set a value using JavaScript.
        //protected override void SetValue(string value)
        //{
        //    Driver.ExecuteScript(
        //        "arguments[0].contentDocument.getElementsByClassName('cke_editable_themed')[0].innerHTML = arguments[1];",
        //        Scope, // Actual CKEditor <iframe> element.
        //        value);
        //}
    
        protected void DoWithinFrame(Action<IWebElement> frameBodyAction)
        {
            var frame = Driver.SwitchTo().Frame(Scope);
            var frameBody = frame.Get(By.TagName("body"));
    
            frameBodyAction?.Invoke(frameBody);
    
            Driver.SwitchTo().DefaultContent();
        }
    }
