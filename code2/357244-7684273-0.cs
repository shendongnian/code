    form.Invoke(new MethodInvoker(() => {
           FileData fileData = listViewFiles.SelectedItem as FileData; // ERROR HERE
            if (fileData != null)
            {
                string name = fileData.FileName;
                foreach (var action in _actionCollection)
                {
                    name = action.Rename(name);
                }
                previewLabel.Content = name;
            }
       }));
