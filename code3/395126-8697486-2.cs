            var sortDescriptions = lstCars.Items.SortDescriptions;
            for (int nI = sortDescriptions.Count; nI >= 0; nI--)
            {
                if (sortDescriptions[nI].PropertyName == cbxSortSecondary.SelectedItem.ToString())
                {
                    sortDescriptions.RemoveAt(nI);
                }
            }
