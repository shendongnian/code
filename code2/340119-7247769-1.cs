    <script runat="server">
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
    
            if (Request.Browser.Browser.ToLowerInvariant() == "firefox")
            {    
                System.Reflection.FieldInfo browserCheckedField = typeof(RadEditor).GetField("_browserCapabilitiesRetrieved", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);    
                browserCheckedField.SetValue(RadEditor1, true);    
                System.Reflection.FieldInfo browserSupportedField = typeof(RadEditor).GetField("_isSupportedBrowser", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);    
                browserSupportedField.SetValue(RadEditor1, true);
            }                        
        }
    </script>   
