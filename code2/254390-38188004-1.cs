        private static string GetOwnerDisplayName(PendingSet[] pending)
        {
            var result = pending.FirstOrDefault(pendingSet => pendingSet.Computer != Environment.MachineName) ?? pending[0];
            return result.OwnerDisplayName;
        }
        private string CheckoutFileInternal(string[] wsFiles, string folder = null)
        {
            try
            {
                var workspaceInfo = Workstation.Current.GetLocalWorkspaceInfo(folder);
                var server = new TfsTeamProjectCollection(workspaceInfo.ServerUri);
                var workspace = workspaceInfo.GetWorkspace(server);
                var request = new GetRequest(folder, RecursionType.Full, VersionSpec.Latest);
                GetStatus status = workspace.Get(request, GetOptions.None);
                int result = workspace.PendEdit(wsFiles, RecursionType.Full, null, LockLevel.None);
                if (result == wsFiles.Length)
                {
                    //TODO: write info (succeed) to log here - messageText
                    return null;
                }
                var pending = server.GetService<VersionControlServer>().QueryPendingSets(wsFiles, RecursionType.None, null, null);
                var messageText = "Failed to checkout !.";
                if (pending.Any())
                {
                    messageText = string.Format("{0}\nFile is locked by {1}", messageText, GetOwnerDisplayName(pending));
                }
                //TODO: write error to log here - messageText
                return messageText;
            }
            catch (Exception ex)
            {
                UIHelper.Instance.RunOnUiThread(() =>
                {
                    MessageBox.Show(Application.Current.MainWindow, string.Format("Failed checking out TFS files : {0}", ex.Message), "Check-out from TFS",
                                   MessageBoxButton.OK, MessageBoxImage.Error);
                });
                return null;
            }
        }
        public async Task<string> CheckoutFileInternalAsync(string[] wsFiles, string folder)
        {
            return await Task.Run(() => CheckoutFileInternal(wsFiles, folder));
        }
