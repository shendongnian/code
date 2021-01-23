    using Microsoft.WindowsAPICodePack.Dialogs;
    var dlg = new CommonOpenFileDialog();
    dlg.Title = "My Title";
    dlg.IsFolderPicker = true;
    dlg.InitialDirectory = currentDirectory;
    dlg.AddToMostRecentlyUsedList = false;
    dlg.AllowNonFileSystemItems = false;
    dlg.DefaultDirectory = currentDirectory;
    dlg.EnsureFileExists = true;
    dlg.EnsurePathExists = true;
    dlg.EnsureReadOnly = false;
    dlg.EnsureValidNames = true;
    dlg.Multiselect = false;
    dlg.ShowPlacesList = true;
    if (dlg.ShowDialog() == CommonFileDialogResult.Ok) {
      var folder = dlg.FileName;
      // Do something with selected folder string
      }
    }
