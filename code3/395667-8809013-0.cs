        private void button1_Click(object sender, EventArgs e)
        {
            //To launch Powepoint
            PowerPoint.Application objPPT = new PowerPoint.Application();
            objPPT.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
            //Add new presentation
            PowerPoint.Presentations oPresSet = objPPT.Presentations;
            PowerPoint.Presentation oPres = oPresSet.Add(Microsoft.Office.Core.MsoTriState.msoTrue);
            //Add a slide
            PowerPoint.Slides oSlides = oPres.Slides;
            PowerPoint.Slide oSlide = oSlides.Add(1, PowerPoint.PpSlideLayout.ppLayoutTitleOnly);
            //Add text
            PowerPoint.TextRange tr = oSlide.Shapes[1].TextFrame.TextRange;
            tr.Text = "Launch notepad";
            //tr.Select();
            //Add Action settings on the shape
            oSlide.Shapes[1].ActionSettings[PowerPoint.PpMouseActivation.ppMouseClick].Action = PowerPoint.PpActionType.ppActionRunProgram;
            oSlide.Shapes[1].ActionSettings[PowerPoint.PpMouseActivation.ppMouseClick].Run = @"C:\WINDOWS\system32\notepad.exe";
            oSlide.Shapes[1].ActionSettings[PowerPoint.PpMouseActivation.ppMouseClick].Action = PowerPoint.PpActionType.ppActionRunProgram;
            oSlide.Shapes[1].ActionSettings[PowerPoint.PpMouseActivation.ppMouseClick].Run = @"C:\WINDOWS\system32\notepad.exe";
            //start slideshow
            objPPT.ActivePresentation.SlideShowSettings.Run();
        }
