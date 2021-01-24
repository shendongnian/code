            public ICommand CopyCommand => new RelayCommand<object>(Copy);
            private static void Copy(object obj)
            {
                Clipboard.SetDataObject(((ViewModel)obj).People);
            }
