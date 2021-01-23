        private CssStyleCollection iStyle;
        public string Style 
        {
            get
            {
                if (iStyle == null)
                {
                    iStyle = CreateStyle(ViewState);                    
                }
                return iStyle.Value;
            }
            set
            {
                if (iStyle == null)
                {
                    iStyle = CreateStyle(ViewState);                    
                }
                //Could add differnet logic here
                iStyle.Value += value == null ? string.Empty : value;
            }
        }
        private static CssStyleCollection CreateStyle(StateBag aViewState)
        {
            var tType = typeof(CssStyleCollection);
            var tConstructors = tType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var tConstructor in tConstructors)
            {
                var tArgs = tConstructor.GetParameters();
                if (tArgs.Length == 1 && tArgs[0].ParameterType == typeof(StateBag))
                {
                    return (CssStyleCollection)tConstructor.Invoke(new object[] { aViewState });
                }
            }
            return null;
        }
        protected override void Render(HtmlTextWriter aOutput)
        {
            aOutput.AddAttribute("style", iStyle.Value);
            aOutput.RenderBeginTag("span");
            foreach (Control tControl in this.Controls)
            {
                tControl.RenderControl(aOutput);
            }
            aOutput.RenderEndTag();            
        }
