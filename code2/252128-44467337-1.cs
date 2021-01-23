    using System.Diagnostics;
    using System.Threading.Tasks;
        
    private async void SoftBlink(Control ctrl, Color c1, Color c2, short CycleTime_ms, bool BkClr)
    {
        var sw = new Stopwatch(); sw.Start();
        short halfCycle = (short)Math.Round(CycleTime_ms * 0.5);
        while (true)
        {
            await Task.Delay(1);
            var n = sw.ElapsedMilliseconds % CycleTime_ms;
            var per = (double)Math.Abs(n - halfCycle) / halfCycle;
            var red = (short)Math.Round((c2.R - c1.R) * per) + c1.R;
            var grn = (short)Math.Round((c2.G - c1.G) * per) + c1.G;
            var blw = (short)Math.Round((c2.B - c1.B) * per) + c1.B;
            var clr = Color.FromArgb(red, grn, blw);
            if (BkClr) ctrl.BackColor = clr; else ctrl.ForeColor = clr;
        }
    }
