    private void CheckResultAccordion(IEnumerable<ListSearchResult> results)
            {
                ResultAccordion.ItemsSource = null;
                ResultAccordion.ItemsSource = results;
                ResultAccordion.UpdateLayout();
                OpenAllAccordionItems(results.Count());
                ResultAccordion.Visibility = Visibility.Visible;
            }
    
    private void OpenAllAccordionItems(int count)
            {
                while (count > 1)
                {
                    ResultAccordion.SelectedIndex = count - 1;
                    count--;
                }
            }
