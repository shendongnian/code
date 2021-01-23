            bool scenarioOne = Coding.EnumHas(fieldSelectionChanges, FieldSelectionChanges.AddedFieldItem);
    		bool scenarioTwo = Coding.EnumHas(fieldSelectionChanges, FieldSelectionChanges.Summary);
    		bool scenarioThree = Coding.EnumHas(fieldSelectionChanges, FieldSelectionChanges.Order) || Coding.EnumHas(fieldSelectionChanges, FieldSelectionChanges.AddedCustomFieldItem) || Coding.EnumHas(fieldSelectionChanges,FieldSelectionChanges.RemovedItem);
    		
    		if (scenarioOne || scenarioTwo)
    			StartEditMode();
    			
    		if (scenarioOne) {
    			SetColumnDescriptorsToAdd(newFieldItemsSelected);
    			UpdateItems(selectedFieldItems);
            }
    		else if (scenarioTwo || scenarioThree) {
    			UpdateItems(fieldItems);
    		}
    		
    		if (scenarioOne || scenarioTwo || scenarioThree)
    			SetColumnsToShow();
