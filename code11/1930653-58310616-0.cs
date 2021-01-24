    public class PanelEx : Panel {
        ...
        public Label MyLabel { get; set; }
    }
    public PanelEx nameoffunction() {
        ...
        MyPanel.MyLabel = MyLabel;
        return MyPanel;
    }
