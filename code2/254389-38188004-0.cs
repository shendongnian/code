      #region Check Out
        public bool CheckOut(string path)
        {
            using (TfsTeamProjectCollection pc = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(ConstTfsServerUri)))
            {
                if (pc == null) return false;
                WorkspaceInfo workspaceInfo = Workstation.Current.GetLocalWorkspaceInfo(path);
                Workspace workspace = workspaceInfo?.GetWorkspace(pc);
                return workspace?.PendEdit(path, RecursionType.Full) == 1;
            }
        }
        public async Task<bool> CheckoutAsync(string path)
        {
            return await Task.Run(() => CheckOut(path));
        }
        #endregion
