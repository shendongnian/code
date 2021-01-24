diff
            switch (value)
            {
                case State.INACTIVE:
                    return Utilities.ResourceDictionary["HoverOverColourInactive"] as Brush;
                case State.ACTIVE:
                    return Utilities.ResourceDictionary["HoverOverColourActive"] as Brush;
                case State.ACTIVE_GROUP_SET:
                    return Utilities.ResourceDictionary["BackgroundBasedOnGroupColour"] as Brush;
                case State.HIGHLIGHTED:
                    return Utilities.ResourceDictionary["HighlightThemeColour"] as Brush;
                case State.PROCESSING:
                    return Utilities.ResourceDictionary["ProcessingWellColour"] as Brush;
                default:
-                    return Brushes.Transparent.Color;
+                    return Brushes.Transparent;
            }
