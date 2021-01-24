    public RelayCommand<PersonForListDto> EditPersonRowCommand
            {
                get
                {
                    return editPersonRowCommand ??
                           (editPersonRowCommand =
                               new RelayCommand<PersonForListDto>(param => this.EditPersonRow(param), this.editPersonRowCommandCanExecute));
                }
            }
