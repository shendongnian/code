            if (e.EditAction == DataFormEditAction.Commit)
            {
                ...
            }
            else
            {
                DataForm1.ValidationSummary.Errors.Clear();
            }
        }
