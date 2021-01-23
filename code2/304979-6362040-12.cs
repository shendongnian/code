      public ModalDialogViewModel Dialog // dialog view binds to this
      {
          get
          {
              return _dialog;
          }
          set
          {
              _dialog = value;
              base.OnPropertyChanged("Dialog");
          }
      }
      public void AskSave()
        {
            Action OkCallback = () =>
            {
                if (Dialog != null) Dialog.Hide();
                Save();
            };
            if (Email.Length < 10)
            {
                Dialog = new ModalDialogViewModel("This email seems a bit too short, are you sure you want to continue saving?",
                                                ModalDialogViewModel.DialogButtons.Ok,
                                                ModalDialogViewModel.CreateCommands(new Action[] { OkCallback }));
                Dialog.Show();
                return;
            }
            
            if (LastName.Length < 2)
            {
                Dialog = new ModalDialogViewModel("The Lastname seems short. Are you sure that you want to save this Customer?",
                                                  ModalDialogViewModel.CreateButtons(ModalDialogViewModel.DialogMode.TwoButton,
                                                                                     new string[] {"Of Course!", "NoWay!"},
                                                                                     OkCallback,
                                                                                     () => Dialog.Hide()));
                Dialog.Show();
                return;
            }
            Save(); // if we got here we can save directly
        }
