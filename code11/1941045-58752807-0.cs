var mock = new Mock<IDialogService>();
mock.Setup(x => x.ShowDialog(It.IsAny<string>(), It.IsAny<IDialogParameters>(), It.IsAny<Action<IDialogResult>>())
    .Callback((string name, IDialogParameters parameters, Action<IDialogResult> callback) =>
        callback(new DialogResult(ButtonResult.Ok)));
...
thing.AbortDeleteDialog();
