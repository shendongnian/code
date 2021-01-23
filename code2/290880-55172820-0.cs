                try {
                // Find the corresponding reference and remove it
                for(int i = 0; i < imageInfoList.Count; i++) {
                    ImageInfo imageInfo = imageInfoList[i];
 
                    if(image == imageInfo.Image) {
                        if((onFrameChangedHandler == imageInfo.FrameChangedHandler) || (onFrameChangedHandler != null && onFrameChangedHandler.Equals(imageInfo.FrameChangedHandler))) {
                            imageInfoList.Remove(imageInfo);
                        }
                        break;
                    }
                }
            }
