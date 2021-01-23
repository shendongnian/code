     internal class ImagesViewPanelDragSourceAdvisor : IDragSourceAdvisor
     {
         private FrameworkElement _dragSource;
 
         public DependencyObject DragSource
         {
             get
             {
                 return _dragSource;
             }
             set
             {
                 _dragSource = value as FrameworkElement;
             }
         }
 
         public DependencyObject DragObject { get; set; }
 
         public DragDropEffects GetDragDropEffects()
         {
             DragDropEffects effects = DragDropEffects.None;
 
             FrameworkElement frameworkObj = DragObject as FrameworkElement;
 
             if (frameworkObj != null && frameworkObj.DataContext is ImageViewModel)
             {
                 effects = DragDropEffects.Copy;
             }
 
             return effects;
         }
 
         public IDataObject GetDragDataObject()
         {
             Debug.Assert(GetDragDropEffects() != DragDropEffects.None);
 
             ImagesViewModel imagesVM = (FrameworkElement)DragSource).DataContext  as ImagesViewModel;
 
             StringCollection fileList = new StringCollection();
 
             foreach (ImageViewModel imageVM in imagesVM.Items.Where(imageVM => imageVM.IsSelected))
             {
                 fileList.Add(imageVM.ImagePath);
             }
 
             Debug.Assert(fileList.Count > 0);
 
             DataObject dataObj = new DataObject();
 
             dataObj.SetFileDropList(fileList);
 
             return dataObj;
         }
 
         public void FinishDrag(DragDropEffects finalEffect)
         {
         }
