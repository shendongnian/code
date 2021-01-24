		private const string	kLicenseWindowAutomationID		= "CheckoutForm";
		private const string	kLicenseButtonAutomationID		= "btnLicense";
		private delegate void	SafeCallDelegate(Control buttonRef);
		private void	RegisterEventListener()
		{
			Automation.AddAutomationEventHandler(
				WindowPattern.WindowOpenedEvent,
				AutomationElement.RootElement,
				TreeScope.Children,
				(sender, e) => 
			{
				AutomationElement	element = sender as AutomationElement;
				string				automationID = element.Current.AutomationId;
				if (automationID != kLicenseWindowAutomationID) return;
				AutomationElement licenseButton = element.FindFirst(
					TreeScope.Descendants,
					new PropertyCondition(AutomationElement.AutomationIdProperty, kLicenseButtonAutomationID));
				if (licenseButton != null) {
					IntPtr		hwnd = new IntPtr(licenseButton.Current.NativeWindowHandle);
					Control		buttonRef = Control.FromHandle(hwnd);
					HideButtonSafe(buttonRef);
				}
			});
		}
		private void HideButtonSafe(Control buttonRef)
		{
			if (buttonRef.InvokeRequired) {
				var d = new SafeCallDelegate(HideButtonSafe);
				buttonRef.Invoke(d, new object[] { buttonRef });
			} else {
				buttonRef.Hide();
			}
		}
