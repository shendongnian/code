    class ThumbnailView
    {
        public Guid WindowGuid { get; set; }
        public Window ApplicationWindowInstance { get; set; }
        public Border ThumbnailVisual
        {
            get {
                return (this.ApplicationWindowInstance.
                                Template.FindName("VisualTarget", 
                                this.ApplicationWindowInstance) as Border);
            }
        }
    }
    
    <Border BorderThickness="0,0,0,0" Cursor="Hand">
        <Border.Background>
            <VisualBrush Visual="{Binding ThumbnailVisual}"/>
        </Border.Background>
    </Border>
