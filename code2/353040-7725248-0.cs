    public interface IButton : IControl
        {
            voie SUbscribeOnClick(EventHandler click);
        }
    public class ButtonStub : IButton
        {
            EventHandler click;
    
            public bool Enabled { get; set; }
    
            public void SubscribeOnClick(EventHandler click)
            {
                this.click = click;
            }
    
            public string Text { get; set; }
    
            public void RaiseClickEvent()
            {
                click(this, EventArgs.Empty);
            }
        }
