           {
              // Write...
              // Call to release any locks
              ReleaseIFsiItems(fileSystemImage.Root);
               // Complete tidy up...
              Marshal.FinalReleaseComObject(fileSystem);
              Marshal.FinalReleaseComObject(fileSystemImageResult);
            }
     private static void ReleaseIFsiItems(IFsiDirectoryItem rootItem)
      {
         if (rootItem == null)
         {
            return;
         }
         var enm = rootItem.GetEnumerator();
         while (enm.MoveNext())
         {
            var currentItem = enm.Current as IFsiItem;
            var fsiFileItem = currentItem as IFsiFileItem;
            if (fsiFileItem != null)
            {
               try
               {
                  var stream = fsiFileItem.Data;
                  var iUnknownForObject = Marshal.GetIUnknownForObject(stream);
                  // Get a reference - things go badly wrong if we release a 0 ref count stream!
                  var i = Marshal.AddRef(iUnknownForObject);
                  // Release all references
                  while (i > 0)
                  {
                     i = Marshal.Release(iUnknownForObject);
                  }
                  Marshal.FinalReleaseComObject(stream);
               }
               catch (COMException)
               {
                  // Thrown when accessing fsiFileItem.Data
               }
            }
            else
            {
               ReleaseIFsiItems(currentItem as IFsiDirectoryItem);
            }
         }
      }
