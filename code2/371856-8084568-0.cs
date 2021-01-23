    Foreach plugin dynamically loaded
    {
        //Via reflection
        Foreach field in the plugin
        {
            See if the field has an attribute attached
            Find the field who's name is the same as it's attribute's name
            {
                Using some lookup method, find the object in the CarSystem
                collection who's name is the same as the attribute name.
                create a concurrencyQueue using proxy object
                call field.SetValue(pluginObject, new Proxy Object) //Reflection call
            }
        }
    }
