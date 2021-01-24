    * In C# they look like this:
            public class Control : Component
            {
                public event EventHandler Click;
                protected virtual void OnClick(EventArgs e)
                {
                    this.Click?.Invoke( this, e ); 
                }
            }
