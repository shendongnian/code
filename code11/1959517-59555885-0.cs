        private void RunMerge()
        {
            string dataPath = @"C:\Data\";
            DirectoryInfo[] folders = GetFoldernames(dataPath);
            var order = FillInClass();
            string typePath = null;
            StringBuilder sb = new StringBuilder();
            string searchPattern = "*log*.xlsx";
            var viewModel = new MainWindowViewModel
            {
                Order = order
            };
            foreach (var (q, toBeSelectedFolder) in from q in order.Questions
                                                    from toBeSelectedFolder in folders
                                                    select (q, toBeSelectedFolder))
            {
                sb.AppendLine($"{ toBeSelectedFolder }");
                typePath = toBeSelectedFolder.FullName.ToString();
                q.Answers.Add(new Answer()
                {
                    TopLevel = viewModel,
                    Ans = toBeSelectedFolder.ToString(),
                    Files = AddDatalogList(new List<Datalog>(), GetFilenames(typePath, searchPattern))
                });
            }
            DataContext = viewModel;
        }
