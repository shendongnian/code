            var control = ControlResolver.ResolveControl(controlType);
            // ... do common logic for all controls
            var list = control as IDynamicList;
            if (list != null)
            {
                // .. do additional logic for list controls
            }
