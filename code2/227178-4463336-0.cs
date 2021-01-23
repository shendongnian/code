        foreach (Control control in controlCollection)
        {
            if (control.GetType() == typeof(T))
                resultCollection.Add((T)control);
    
            if (control.HasControls())
                GetControlList(controlCollection, ref resultCollection);
        }
    }
