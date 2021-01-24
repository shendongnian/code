    class BackupOverviewViewModel : INotifyPropertyChanged
    {
      public BackupOverviewViewModel()
      {
        this.TableRows = new ObservableCollection<TableRowDataModel>();
        CreateTableRowData();
      }
      private void CreateTableRowData()
      {
        // Read
        string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string folderPath = userPath + @"\WindowsBackupFoldersToExternalDisk\backupOverview";
        if (Directory.Exists(folderPath))
        {
          // Process the list of files found in the directory.
          IEnumerable<string> fileEntries = Directory.EnumerateFiles(folderPath);
          foreach (string file in fileEntries)
          {
            // Read file "directoriesFiles"
            foreach (string line in File.ReadLines(directoriesFile)
            {
              if (!string.IsNullOrWhiteSpace(line))
              {
                // Design:  dateTime + "|" + source + "|" + rootDirectory + "|" + sourceDirectoryName + "|" + sourcePath + "|" + sourceFile + "|" + targetLetter + "|" + targetDiskName
                // Example: 28 juli 2019 21:29:10|C:\SourceA|C:\SourceA\7875000|7875000|C:\SourceA\7875000\Raw images|img003.txt|D:\|-
                string[] lineArray = line.Split(new[] {'|'}, StringSplitOptions.None);
                String dateTime = lineArray[0];
                String source = lineArray[1];
                String rootDirectory = lineArray[2];
                String sourceDirectoryName = lineArray[3];
                String sourcePath = lineArray[4];
                String sourceFile = lineArray[5];
                String targetLetter = lineArray[6];
                String targetDiskName = lineArray[7];
                var tableRowDataModel = new TableRowDataModel(
                  dateTime,
                  source,
                  rootDirectory,
                  sourceDirectoryName,
                  sourcePath,
                  sourceFile,
                  targetLetter,
                  targetDiskName);
                this.TableRows.Add(tableRowModel);
              }
            }
          }
        }
      }
      public ObservableCollection<TableRowDataModel> TableRows { get; set; }
      #region INotifyPropertyChanged
      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
      #endregion
    }
