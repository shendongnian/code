        public System.IO.Stream GetSytleFile(String widgetID)
        {            
            IWidget w = GetWidget(widgetID);
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/css";
            return StreamBytes(w.GetEditorStyleFile());
        }
