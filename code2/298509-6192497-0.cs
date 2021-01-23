    public static void AttachBoardControl()
    {
        pageInstance.stackPanelAssetsControl.Children.Clear();
        pageInstance.stackPanelAssetsControl.Children.Add(SilverlightForum.App.forumBoardControl);
    }
