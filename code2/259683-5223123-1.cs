                // PERCENTAGE OF IMAGE -> TODO: Configurable? IMAZE ZOOM / SCREEN PERCENTAGE
                Double HScale = __bmp.Width;// *Defs.SCREEN_SIZE / 100;
                Double VScale = __bmp.Height;// *Defs.SCREEN_SIZE / 100;
                Double __aspectRatio;
                Double __screenRatio = _currentScreenSize.Width / _currentScreenSize.Height;
                // PERCENTAGE OF SCREEN
                if (!_boolPixelAR) {
                    HScale = _currentScreenSize.Width * Defs.SCREEN_SIZE / 100;
                    VScale = _currentScreenSize.Height * Defs.SCREEN_SIZE / 100;
                }
                else {
                    __aspectRatio = HScale / VScale;
                    if( __aspectRatio >= 1)
                        if (HScale >= _currentScreenSize.Width) {  // Long Edge is WIDTH. For 100%, HScale = WIDTH
                            VScale = ((VScale * _currentScreenSize.Width) / HScale) * Defs.SCREEN_SIZE / 100;
                            HScale = _currentScreenSize.Width * Defs.SCREEN_SIZE / 100;
                            if (VScale > _currentScreenSize.Height) {                  // Long Edge is HEIGHT. For 100%, VScale = HEIGHT
                                //__aspectRatio = VScale / HScale;
                                HScale = ((HScale * _currentScreenSize.Height) / VScale) * Defs.SCREEN_SIZE / 100;
                                VScale = _currentScreenSize.Height * Defs.SCREEN_SIZE / 100;
                            }
                        }
                        else if (VScale > _currentScreenSize.Height) {                  // Long Edge is HEIGHT. For 100%, VScale = HEIGHT
                            //__aspectRatio = VScale / HScale;
                            HScale = ((HScale * _currentScreenSize.Height) / VScale) * Defs.SCREEN_SIZE / 100;
                            VScale = _currentScreenSize.Height * Defs.SCREEN_SIZE / 100;
                        } 
                        else {
                            //Do nothing... Just set Zoom.
                            HScale = HScale * Defs.SCREEN_SIZE / 100;
                            VScale = VScale * Defs.SCREEN_SIZE / 100;
                        }
                    else 
                        if (VScale > _currentScreenSize.Height) {                  // Long Edge is HEIGHT. For 100%, VScale = HEIGHT
                            //__aspectRatio = VScale / HScale;
                            HScale = ((HScale * _currentScreenSize.Height) / VScale) * Defs.SCREEN_SIZE / 100;
                            VScale = _currentScreenSize.Height * Defs.SCREEN_SIZE / 100;
                        }
                        else if (HScale >= _currentScreenSize.Width) {  // Long Edge is WIDTH. For 100%, HScale = WIDTH
                            VScale = ((VScale * _currentScreenSize.Width) / HScale) * Defs.SCREEN_SIZE / 100;
                            HScale = _currentScreenSize.Width * Defs.SCREEN_SIZE / 100;
                        } 
                        else {
                            //Do nothing... Just set Zoom.
                            HScale = HScale * Defs.SCREEN_SIZE / 100;
                            VScale = VScale * Defs.SCREEN_SIZE / 100;
                        }
                    ////__aspectRatio = VScale / HScale;
                    //HScale = ((HScale * _currentScreenSize.Height) / VScale) * Defs.SCREEN_SIZE / 100;
                    //VScale = _currentScreenSize.Height * Defs.SCREEN_SIZE / 100;
                }
                Bitmap scaledBmp = GraphicsFactory.ResizeImage(
                                            __bmp,
                                            Convert.ToInt32(HScale),
                                            Convert.ToInt32(VScale));
