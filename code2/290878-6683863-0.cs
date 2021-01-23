     /// <devdoc> 
        ///     Worker thread procedure which implements the main animation loop.
        ///     NOTE: This is the ONLY code the worker thread executes, keeping it in one method helps better understand
        ///     any synchronization issues.
        ///     WARNING: Also, this is the only place where ImageInfo objects (not the contained image object) are modified, 
        ///     so no access synchronization is required to modify them.
        /// </devdoc> 
        [SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals")] 
        static void AnimateImages50ms() {
            Debug.Assert(imageInfoList != null, "Null images list"); 
            while( true ) {
                // Acquire reader-lock to access imageInfoList, elemens in the list can be modified w/o needing a writer-lock.
                // Observe that we don't need to check if the thread is waiting or a writer lock here since the thread this 
                // method runs in never acquires a writer lock.
                rwImgListLock.AcquireReaderLock(Timeout.Infinite); 
                try { 
                    for (int i=0;i < imageInfoList.Count; i++) {
                        ImageInfo imageInfo = imageInfoList[i]; 
                        // Frame delay is measured in 1/100ths of a second. This thread
                        // sleeps for 50 ms = 5/100ths of a second between frame updates,
                        // so we increase the frame delay count 5/100ths of a second 
                        // at a time.
                        // 
                        imageInfo.FrameTimer += 5; 
                        if (imageInfo.FrameTimer >= imageInfo.FrameDelay(imageInfo.Frame)) {
                            imageInfo.FrameTimer = 0; 
                            if (imageInfo.Frame + 1 < imageInfo.FrameCount) {
                                imageInfo.Frame++;
                            } 
                            else {
                                imageInfo.Frame = 0; 
                            } 
                            if( imageInfo.FrameDirty ){ 
                                anyFrameDirty = true;
                            }
                        }
                    } 
                }
                finally { 
                    rwImgListLock.ReleaseReaderLock(); 
                }
 
                Thread.Sleep(50);
            }
        }
