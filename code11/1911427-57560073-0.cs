    Function OpenAccountOpeningPreview(sender As Object,e As UCEventArgs) 
    
        DIm oPreviewOnBoardingContentPane as ContentPane  = new ContentPane()
    
        oPreviewOnBoardingContentPane.Name = "PreviewOnBoardingDocuments"
        oPreviewOnBoardingContentPane.TabHeader = "Preview OnBoarding Documents"
        oPreviewOnBoardingContentPane.AllowDocking = true
        oPreviewOnBoardingContentPane.AllowFloatingOnly = true
        oPreviewOnBoardingContentPane.AllowClose = true
        oPreviewOnBoardingContentPane.Content = e.UCReference
        oPreviewOnBoardingContentPane.TabHeaderTemplate = CType(Resources("TabTemplate"), DataTemplate)
    
        DockGroup.Items.Add(oPreviewOnBoardingContentPane) //Using Infragistics tab
    
        oPreviewOnBoardingContentPane.Visibility = Visibility.Visible
        oPreviewOnBoardingContentPane.Activate()
    
    End Function
