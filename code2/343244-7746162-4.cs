        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var contentRoot = this.GetTemplateChild("ContentRoot") as FrameworkElement;
            contentRoot.LayoutUpdated += contentRoot_LayoutUpdated;
        }
        void contentRoot_LayoutUpdated(object sender, EventArgs e)
        {
            var contentRoot = this.GetTemplateChild("ContentRoot") as FrameworkElement;
            var tg = contentRoot.RenderTransform as TransformGroup;
            var tts = tg.Children.OfType<TranslateTransform>();
            foreach (var t in tts)
            {
                t.X = 0; t.Y = 0;
            }
        }
