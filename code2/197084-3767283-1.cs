            private void UpdataFieldItems(List<FieldItemBase> existingFieldItems, List<FieldItemBase> selectedFieldItems)
            {
                List<FieldItemBase> newFieldItemsSelected;
                var fieldSelectionChanges = GetFieldSelectionChanges(out newFieldItemsSelected);//retuns a Flagged enum
    
                if (IsValidChange(fieldSelectionChanges))
                {
                    List<FieldItemBase> targetfields = null;
                    if (IsInEditMode(fieldSelectionChanges))
                        StartEditMode();
    
                    if (IsItemAdded(fieldSelectionChanges))
                    {
                        SetColumnDescriptorsToAdd(newFieldItemsSelected);
                        targetFields = selectedFieldItems;
                    }
                    else
                        targetFields = existingFieldItems;
    
                    UpdateItems(targetFields);
                    SetColumnsToShow();
    
                    if (IsItemAdded(fieldSelectionChanges))
                        CustomizeAlignmentAndCellFormatters(_tfaTableGrid.TableGrid);
    
                    if (IsInEditMode(fieldSelectionChanges))
                    {
                        if (_tfaTableGrid.TableGrid.ColumnDescriptors.Count() > 0)
                            SetAdditionalFirstGroupedColumn();
                        StopEditMode();
                    }
                }
    
                Invalidate();
            }
    
            private bool InEditMode(FlaggedEnum fieldSelectionChanges)
            {
                return Coding.EnumHas(fieldSelectionChanges, FieldSelectionChanges.Summary) || Coding.EnumHas(fieldSelectionChanges, FieldSelectionChanges.AddedFieldItem);
            }
    
            private bool IsItemAdded(FlaggedEnum fieldSelectionChanges)
            {
                Coding.EnumHas(Coding.EnumHas(fieldSelectionChanges, FieldSelectionChanges.AddedFieldItem);
            }
    
            private bool IsValidChange(FlaggedEnum fieldSelectionChanges)
            {
                return Coding.EnumHas(fieldSelectionChanges, FieldSelectionChanges.Order) ||
                       Coding.EnumHas(fieldSelectionChanges, FieldSelectionChanges.AddedCustomFieldItem) ||
                       Coding.EnumHas(fieldSelectionChanges, FieldSelectionChanges.RemovedItem) ||
                       Coding.EnumHas(fieldSelectionChanges, FieldSelectionChanges.Summary) ||
                       Coding.EnumHas(fieldSelectionChanges, FieldSelectionChanges.AddedFieldItem);
            }
    
            //Coding.cs
            public static bool EnumHas(FieldSelectionChanges selectionChanges, FieldSelectionChanges valueToCheck)
            {
                return (selectionChanges & valueToCheck) == valueToCheck;
            }
