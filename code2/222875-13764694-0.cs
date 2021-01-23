    private static void OnCurrentItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                DataForm dataForm = d as DataForm;
                if (dataForm != null && !dataForm.AreHandlersSuspended())
                {
                    if (dataForm._lastItem != null && dataForm.ShouldValidateOnCurrencyChange)
                    {
                        dataForm.ValidateItem();
                    }
    
                    if ((!dataForm.AutoCommitPreventsCurrentItemChange && dataForm.IsItemValid) &&
                        (e.NewValue == null ||
                        dataForm._collectionView == null ||
                        dataForm._collectionView.Contains(dataForm.CurrentItem) 
                        ))
                    {
                        dataForm.SetUpNewCurrentItem();
                        dataForm.GenerateUI(true /* clearEntityErrors */, true /* swapOldAndNew */);
                        dataForm.UpdateCurrentItem();
                        SetAllCanPropertiesAndUpdate(dataForm, false /* onlyUpdateStates */);
                        dataForm._lastItem = dataForm.CurrentItem;
                        dataForm.OnCurrentItemChanged(EventArgs.Empty);
                    }
                    else
                    {
                        dataForm.SetValueNoCallback(e.Property, e.OldValue);
                        throw new InvalidOperationException(string.Format(Globalization.CultureInfo.InvariantCulture, System.Windows.Controls.Data.DataForm.Toolkit.Resources.DataForm_CannotChangeCurrency, "AutoCommit", "ItemsSource", "ICollectionView"));
                    }
                }
            }
