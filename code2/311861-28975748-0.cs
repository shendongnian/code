      public static class ExtendedCheckBoxList
    {
    
        public static string SelectedValuesAsCommaDelimmittedString( this CheckBoxList thatCheckBoxList )
        {
    
            List<string> selectedValuesAsStrings = thatCheckBoxList.SelectedValuesAsStrings();
    
            string commaDelimmittedStringOfValues = String.Join( ",", selectedValuesAsStrings );
    
            return commaDelimmittedStringOfValues;
        }
    
        
        public static List<string> SelectedValuesAsStrings( this CheckBoxList thatCheckBoxList )
        {
                List<string> selectedValuesAsStrings = thatCheckBoxList
                                                                    .Items
                                                                    .Cast<ListItem>()
                                                                    .Where( i => i.Selected )
                                                                    .Select( i => i.Value )
                                                                    .ToList();
    
                return selectedValuesAsStrings;
        }
    }
