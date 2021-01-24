    private async void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        switch (args.Reason)
        {
            case AutoSuggestionBoxTextChangeReason.ProgrammaticChange:
            case AutoSuggestionBoxTextChangeReason.SuggestionChosen:
                sender.ItemsSource = null;
                return;
        }
        var query = sender.Text;
        var hits = await NutritionixAPI.GetFoods(query);
        List<string> items = new List<string>();
        foreach (var hit in hits)
        {
            string temp = hit.fields.item_name + " Calories: " + hit.fields.nf_serving_size_qty + " Protein: " + hit.fields.nf_serving_size_unit + " Fat: " + hit.fields.item_id;
            if (items.Exists(p => p == temp) == false)
            {
                items.Add(temp);
            }
    
        }
        var Suggestion = items.Where(p => p.StartsWith(sender.Text, StringComparison.OrdinalIgnoreCase)).ToArray();
        sender.ItemsSource = Suggestion;
    }
