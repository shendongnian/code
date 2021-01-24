        static void GetAllWorkItemQueries(string project)
        {
            List<QueryHierarchyItem> rootQueries = WitClient.GetQueriesAsync(project, QueryExpand.All).Result;
            GetFolderContent(project, rootQueries);
        }
        /// <summary>
        /// Get Content from Query Folders
        /// </summary>
        /// <param name="project">Team Project Name</param>
        /// <param name="queries">Folder List</param>
        static void GetFolderContent(string project, List<QueryHierarchyItem> queries)
        {
            foreach(QueryHierarchyItem query in queries)
            {
                if (query.IsFolder != null && (bool)query.IsFolder)
                {
                    Console.WriteLine("Folder: " + query.Path);
                    if ((bool)query.HasChildren)
                    {
                        QueryHierarchyItem detiledQuery = WitClient.GetQueryAsync(project, query.Path, QueryExpand.All, 1).Result;
                        GetFolderContent(project, detiledQuery.Children.ToList());
                    }
                }
                else
                    Console.WriteLine("Query: " + query.Path);
            }
        }
