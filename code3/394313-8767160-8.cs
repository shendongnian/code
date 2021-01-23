        [System.Windows.Browser.ScriptableMember()]
        public void RefreshDiagram()
        {
            // Fetch the hidden input control from the page
            var serializedElement = System.Windows.Browser.HtmlPage.Document.GetElementById("txtSerializedData");
            // Then fetch its value attribute
            var sSerializedData = serializedElement.GetAttribute("value");
            // Finally, do something with sSerializedData
        }
