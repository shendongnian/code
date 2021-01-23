    /// <summary>  
    /// Programatically registers a <see cref="SoapExtension"/> at runtime with the specified  
    /// <see cref="SoapExtensionTypeElement.Priority"/> and <see cref="SoapExtensionTypeElement.Group"/> settings.  
    /// </summary>  
    /// <param name="type">The <see cref="Type"/> of the <see cref="SoapExtension"/> to register.</param>  
    /// <param name="priority">  
    /// A value that indicates the relative order in which this SOAP extension runs when multiple SOAP extensions are  
    /// specified. Within each group the priority attribute distinguishes the overall relative priority of the SOAP   
    /// extension. A lower priority number indicates a higher priority for the SOAP extension. The lowest possible   
    /// value for the priority attribute is 1.  
    /// </param>  
    /// <param name="group">  
    /// The relative priority group (e.g. Low or High) in which this SOAP extension runs when multiple SOAP extensions   
    /// are configured to run.  
    /// </param>  
    [ReflectionPermission(SecurityAction.Demand, Unrestricted = true)]  
    public static void RegisterSoapExtension(Type type, int priority, PriorityGroup group)  
    {  
        if (!type.IsSubclassOf(typeof(SoapExtension)))  
        {  
            throw new ArgumentException("Type must be derived from SoapException.", "type");  
        }  
        if (priority < 1)  
        {  
            throw new ArgumentOutOfRangeException("priority", priority, "Priority must be greater or equal to 1.");  
        }  
        // get the current web services settings...  
        WebServicesSection wss = WebServicesSection.Current;  
        // set SoapExtensionTypes collection to read/write...  
        FieldInfo readOnlyField = typeof(System.Configuration.ConfigurationElementCollection).GetField("bReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);  
        readOnlyField.SetValue(wss.SoapExtensionTypes, false);  
        // inject SoapExtension...  
        wss.SoapExtensionTypes.Add(new SoapExtensionTypeElement(type, priority, group));  
        // set SoapExtensionTypes collection back to readonly and clear modified flags...  
        MethodInfo resetModifiedMethod = typeof(System.Configuration.ConfigurationElement).GetMethod("ResetModified", BindingFlags.NonPublic | BindingFlags.Instance);  
        resetModifiedMethod.Invoke(wss.SoapExtensionTypes, null);  
        MethodInfo setReadOnlyMethod = typeof(System.Configuration.ConfigurationElement).GetMethod("SetReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);  
        setReadOnlyMethod.Invoke(wss.SoapExtensionTypes, null);  
    } 
