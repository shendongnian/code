        foreach (Control control in controlCollection)
        {
            //if (control.GetType() == typeof(T))
            if (control is T) // This is cleaner
                resultCollection.Add((T)control);
    
            if (control.HasControls())
                GetControlList(control.Controls, ref resultCollection);
        }
    }
