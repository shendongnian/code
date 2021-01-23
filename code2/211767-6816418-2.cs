        private static void OnSourceUpdatedHandler(object obj, DataTransferEventArgs e) //// Please double check this signature
        {
            var uiElement = e.TargetObject as UIElement;
            if (uiElement != null)
            {
                ///... your code to validated uiElement.                        
            }
        }
