    <TextBox>
        <TextBox.CommandBindings>
            <CommandBinding Command="{x:Static ApplicationCommands.Copy}"
                            CanExecute="CanCopy"
                            Executed="Copy" />
            <CommandBinding Command="{x:Static ApplicationCommands.Paste}"
                            CanExecute="CanPaste"
                            Executed="Paste" />
        </TextBox.CommandBindings>
    </TextBox>
