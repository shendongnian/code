        public void AddIteration(string projectName, string iterationName)
        {
            using (var tfsCollection = new TfsTeamProjectCollection(new Uri(tfsServerUrl), getTfsCredentials()))
            {
                tfsCollection.Authenticate();
                var css = tfsCollection.GetService<ICommonStructureService>();
                string rootNodePath = string.Format("\\{0}\\Iteration", projectName);
                var pathRoot = css.GetNodeFromPath(rootNodePath);
                css.CreateNode(iterationName, pathRoot.Uri);
            }
        }
