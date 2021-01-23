    <Button Command="{Binding CreateNewExaminationCommand}"></Button>
    RelayCommand createNewExaminationCommand;
    public ICommand CreateNewExaminationCommand
    {
        get
        {
            if (createNewExaminationCommand== null)
            {
                createNewExaminationCommand= new RelayCommand(param => this.CreateNew(),
                    param => this.CanCreateNew);
            }
            return createNewExaminationCommand;
        }
}
