		private int[]			i_checkoutWindID;
		private void	RegisterEventListener()
		{
			Automation.AddAutomationEventHandler(
				WindowPattern.WindowOpenedEvent,
				AutomationElement.RootElement,
				TreeScope.Children,
				(sender, e) => 
			{
				AutomationElement		element = sender as AutomationElement;
				string					automationID = element.Current.AutomationId;
				if (automationID != kLicenseWindowAutomationID) return;
				i_checkoutWindID = element.GetRuntimeId();
				AutomationElement licenseButton = element.FindFirst(
					TreeScope.Descendants,
					new PropertyCondition(AutomationElement.AutomationIdProperty, kLicenseButtonAutomationID));
				if (licenseButton != null) {
					IntPtr		hwnd = new IntPtr(licenseButton.Current.NativeWindowHandle);
					Control		buttonRef = Control.FromHandle(hwnd);
					HideButton_Safe(buttonRef);
				}
			});
			Automation.AddAutomationEventHandler(
				WindowPattern.WindowClosedEvent,
				AutomationElement.RootElement,
				TreeScope.Subtree,
				(sender, e) => 
			{
				WindowClosedEventArgs		args = e as WindowClosedEventArgs;
				
				if (Automation.Compare(args.GetRuntimeId(), i_checkoutWindID)) {
					Array.Clear(i_checkoutWindID, 0, i_checkoutWindID.Length);
					<do your "window closed" callback here>;
				}
			});
		}
		private void HideButton_Safe(Control buttonRef)
		{
			if (buttonRef.InvokeRequired) {
				var d = new SafeCallDelegate_ButtonHide(HideButton_Safe);
				buttonRef.Invoke(d, new object[] { buttonRef });
			} else {
				buttonRef.Hide();
			}
		}
