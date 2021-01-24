    private static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
                {
                    if (!string.IsNullOrWhiteSpace(args.NewTextValue))
                    {
                      
                        //make sure all characters are numbers
                        var isValid = args.NewTextValue.ToCharArray().All(x => char.IsDigit(x));
        
                        if (isValid && args.NewTextValue.Length > 1 && args.NewTextValue.StartsWith("0"))
                            return;
        
                        ((Entry)sender).Text = isValid ? args.NewTextValue : args.NewTextValue.Remove(args.NewTextValue.Length - 1);
                    }
                }
