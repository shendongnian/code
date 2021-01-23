    // Turn the read only field non-readonly
	WebServicesSection wss = WebServicesSection.Current;
	SoapExtensionTypeElement e = new SoapExtensionTypeElement(typeof (TraceExtension), 1, PriorityGroup.High);
	FieldInfo readOnlyField = typeof(System.Configuration.ConfigurationElementCollection).GetField("bReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
	readOnlyField.SetValue(wss.SoapExtensionTypes, false);
    // Bind to web services section of config
	wss.SoapExtensionTypes.Add(e);
    // Restore the original so other things don't break
	MethodInfo resetMethod = typeof(System.Configuration.ConfigurationElementCollection).GetMethod("ResetModified", BindingFlags.NonPublic | BindingFlags.Instance);
    resetMethod.Invoke(wss.SoapExtensionTypes, null);
	MethodInfo setReadOnlyMethod = typeof(System.Configuration.ConfigurationElementCollection).GetMethod("SetReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
	setReadOnlyMethod.Invoke(wss.SoapExtensionTypes, null);
