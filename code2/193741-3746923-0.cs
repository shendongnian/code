            var ctl = new micautLib.MathInputControl();
            var ink = new MSINKAUTLib.InkDisp();
            ink.Load(System.IO.File.ReadAllBytes("c:\\temp\\test.isf"));
            var iink = (micautLib.IInkDisp)ink;
            ctl.Show();
            ctl.LoadInk(iink);
