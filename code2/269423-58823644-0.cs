    /// <summary>
    /// Fade a label - Derek Piper 2019
    /// </summary>
    public class LabelFader
    {
        Label label;
        List<ColorStep> colorSteps = new List<ColorStep>();
        public void attachToControl(Label useLabel)
        {
            this.label = useLabel;
        }
        public void setColorSteps(int numSteps)
        {
            if (this.label != null)
            {
                ColorStep start = new ColorStep(this.label.ForeColor);
                ColorStep end = new ColorStep(this.label.BackColor);
                int redIncrement = ((end.R - start.R) / numSteps);
                int greenIncrement = ((end.G - start.G) / numSteps);
                int blueIncrement = ((end.B - start.B) / numSteps);
                this.colorSteps = new List<ColorStep>();
                for (int i = 0; i <= numSteps; i++)
                {
                    ColorStep newStep = new ColorStep();
                    if (redIncrement > 0)
                    {
                        newStep.R = start.R + (i * redIncrement);
                    }
                    else
                    {
                        newStep.R = start.R - (i * redIncrement);
                    }
                    if (greenIncrement > 0)
                    {
                        newStep.G = start.G + (i * greenIncrement);
                    }
                    else
                    {
                        newStep.G = start.G - (i * greenIncrement);
                    }
                    if (blueIncrement > 0)
                    {
                        newStep.B = start.B + (i * blueIncrement);
                    }
                    else
                    {
                        newStep.B = start.B - (i * blueIncrement);
                    }
                    this.colorSteps.Add(newStep);
                }
            }
        }
        public void doFade(int speedMs = 40)
        {
            Timer tm = new Timer();
            tm.Interval = speedMs;
            int step = 0;
            int end = this.colorSteps.Count;
            if (this.colorSteps.Count > 0)
            {
                tm.Tick += (sa, aea) =>
                {
                    ColorStep thisStep = this.colorSteps[step];
                    this.label.ForeColor = Color.FromArgb(thisStep.R, thisStep.G, thisStep.B);
                    step++;
                    if (step >= end)
                    {
                        tm.Stop();
                        this.label.Visible = false;
                    }
                };
                tm.Start();
            }
        }
    }
    class ColorStep
    {
        public int R = 0;
        public int G = 0;
        public int B = 0;
        public ColorStep()
        {
        }
        public ColorStep(Color from)
        {
            this.setFromColor(from);
        }
        public void setFromColor(Color from)
        {
            this.R = from.R;
            this.G = from.G;
            this.B = from.B;
        }
        public Color getColor()
        {
            return Color.FromArgb(this.R, this.G, this.B);
        }
    }
