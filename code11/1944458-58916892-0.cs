    public LinkHelp(string projectId)
        {
            var linkBuilderoptions = new ContentManagementHelpersOptions() { ProjectId = projectId };
            Builder = new LinkBuil(linkBuildoptions);         
        }
