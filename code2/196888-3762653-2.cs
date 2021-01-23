            /// <summary>
            /// Gets a photo or video clip from the camera
            /// </summary>
            /// <param name="directoryItem">Reference to the item that the camera captured.</param>
            /// <returns></returns>
            private CapturedItem getCapturedItem(IntPtr directoryItem)
            {
                uint err = EDSDK.EDS_ERR_OK;
                IntPtr stream = IntPtr.Zero;
                EDSDK.EdsDirectoryItemInfo dirItemInfo;
                err = EDSDK.EdsGetDirectoryItemInfo(directoryItem, out dirItemInfo);
                if (err != EDSDK.EDS_ERR_OK)
                {
                    throw new CameraException("Unable to get captured item info!", err);
                }
                //  Fill the stream with the resulting image
                if (err == EDSDK.EDS_ERR_OK)
                {
                    err = EDSDK.EdsCreateMemoryStream((uint)dirItemInfo.Size, out stream);
                }
                //  Copy the stream to a byte[] and 
                if (err == EDSDK.EDS_ERR_OK)
                {
                    err = EDSDK.EdsDownload(directoryItem, (uint)dirItemInfo.Size, stream);
                }
                //  Create the returned item
                CapturedItem item = new CapturedItem();
                if (err == EDSDK.EDS_ERR_OK)
                {
                    IntPtr imageRef = IntPtr.Zero;
                    err = EDSDK.EdsCreateImageRef(stream, out imageRef);
                    if (err == EDSDK.EDS_ERR_OK)
                    {
                        EDSDK.EdsImageInfo info;
                        err = EDSDK.EdsGetImageInfo(imageRef, EDSDK.EdsImageSource.FullView, out info);
                        if (err == EDSDK.EDS_ERR_OK)
                        {
                            item.Dimensions = new com.waynehartman.util.graphics.Dimension((int)info.Width, (int)info.Height);
                            EDSDK.EdsRelease(imageRef);
                        }
                    }
                }
                if (err == EDSDK.EDS_ERR_OK)
                {
                    byte[] buffer = new byte[(int)dirItemInfo.Size];
                    GCHandle gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                    IntPtr address = gcHandle.AddrOfPinnedObject();
                    IntPtr streamPtr = IntPtr.Zero;
                    err = EDSDK.EdsGetPointer(stream, out streamPtr);
                    if (err != EDSDK.EDS_ERR_OK)
                    {
                        throw new CameraDownloadException("Unable to get resultant image.", err);
                    }
                    try
                    {
                        Marshal.Copy(streamPtr, buffer, 0, (int)dirItemInfo.Size);
                        item.Image = buffer;
                        item.Name = dirItemInfo.szFileName;
                        item.Size = (long)dirItemInfo.Size;
                        item.IsFolder = Convert.ToBoolean(dirItemInfo.isFolder);
                        return item;
                    }
                    catch (AccessViolationException ave)
                    {
                        throw new CameraDownloadException("Error copying unmanaged stream to managed byte[].", ave);
                    }
                    finally
                    {
                        gcHandle.Free();
                        EDSDK.EdsRelease(stream);
                        EDSDK.EdsRelease(streamPtr);
                    }
                }
                else
                {
                    throw new CameraDownloadException("Unable to get resultant image.", err);
                }
            }
