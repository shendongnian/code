     // PictureContentContorl                        
        Microsoft.Office.Tools.Word.PictureContentControl ct;
        // Removing the control if already exists
                           Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveDocument).Controls.Remove("HeaderLogo");
        // adding control to a range rng
                                ct = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveDocument).Controls.AddPictureContentControl(rng, "HeaderLogo");
                                ct.Image = Properties.Resources.my_logo;
                                ct = null;
