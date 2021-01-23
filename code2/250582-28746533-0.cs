    List<PointF> drawDonut(float angleA, float angleB, float width, int controlPointCount, float scaling, float centerX, float centerY)
        {
            List<PointF> points = new List<PointF>();
            if (controlPointCount < 2)
            {
                throw (new ArgumentOutOfRangeException("controlPointCount", "controlPointCount must be >1"));
            }
            if (width <= 0 || width > 100)
            {
                throw (new ArgumentOutOfRangeException("width", "width must be comprised between ]0:100]"));
            }
            List<float> angles = new List<float>();
            for (int i = 0; i < controlPointCount; i++)
            {
                angles.Add(angleA + (angleB - angleA) * (float)i / ((float)controlPointCount - 1.0f));
            }
            for (int i = 0; i < angles.Count; i++)
            {
                points.Add(new PointF((float)Math.Cos(angles[i]) * scaling + centerX, (float)Math.Sin(angles[i]) * scaling + centerY));
            }
            for (int i = 0; i < angles.Count; i++)
            {
                points.Add(new PointF(((100.0f - width) / 100.0f * (float)Math.Cos(angles[angles.Count - 1 - i])) * scaling + centerX, ((100.0f - width) / 100.0f * (float)Math.Sin(angles[angles.Count - 1 - i])) * scaling + centerY));
            }
            return points;
        }
        private List<Color> pieColor(Color[] MainColors, float[] mainStops, float[] stops)
        {
            List<Color> resultColors = new List<Color>();
            int index = 0;
            float percent;
            if (MainColors.Length != mainStops.Length)
            {
                throw new Exception("number of MainColors and mainStops must be the same");
            }
            if (MainColors.Length < 2)
            {
                for (int i = 0; i < stops.Length; i++)
                {
                    resultColors.Add((MainColors.Length == 1) ? MainColors[0] : Color.White);
                }
            }
            else
            {
                for (int i = 0; i < stops.Length; i++)
                {
                    index = Array.FindIndex(mainStops, x => x > stops[i]);
                    if (index == 0)
                    {
                        resultColors.Add(MainColors[0]);
                    }
                    else
                    {
                        if (index == mainStops.Length - 1 || index == -1)
                        {
                            resultColors.Add(MainColors.Last());
                        }
                        else
                        {
                            percent = (stops[i] - mainStops[index - 1]) / (mainStops[index] - mainStops[index - 1]) * 100f;
                            resultColors.Add(alphaBlend(MainColors[index - 1], MainColors[index], percent));
                        }
                    }
                }
            }
            return resultColors;
        }
        private Color alphaBlend(Color color1, Color color2, float percent)
        {
            byte R = (byte)(((float)color1.R * (100f - percent) / 100f) + ((float)color2.R * (percent) / 100f));
            byte G = (byte)(((float)color1.G * (100f - percent) / 100f) + ((float)color2.G * (percent) / 100f));
            byte B = (byte)(((float)color1.B * (100f - percent) / 100f) + ((float)color2.B * (percent) / 100f));
            return Color.FromArgb(R, G, B);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            RectangleF rec = e.ClipRectangle;
            float midx = rec.Width / 2;
            float midy = rec.Height / 2;
            float pieSize = (float)Math.Min(midx, midy) * 0.9f;
            float pieWidth = 5f;
            float angleA = -225;
            float angleB = 45;
            int nstops = (int)(Math.Abs(angleA - angleB) / 5 + 1);
            float[] stops;
            stops = new float[nstops];
            for (int i = 0; i < stops.Length; i++)
            {
                stops[i] = i * 100f / (stops.Length - 1);
            }
            List<PointF> myDonut = drawDonut(angleA * (float)Math.PI / 180f, angleB * (float)Math.PI / 180f, pieWidth, nstops, pieSize, midx, midy);
            List<Color> myColors = pieColor(new Color[] { Color.Red, Color.Yellow, Color.Green, Color.Cyan, Color.Blue, Color.Magenta, Color.Red },
                                            new float[] { 0.0f, 100f / 6f, 200f / 6f, 300f / 6f, 400f / 6f, 500f / 6f, 600f / 6f },
                                            stops);
            Color[] myPieColor = new Color[myDonut.Count];
            for (int i = 0; i < (myPieColor.Length / 2); i++)
            {
                myPieColor[i] = myColors[i];
                myPieColor[myPieColor.Length - i - 1] = myColors[i];
            }
            GraphicsPath gp = new GraphicsPath();
            gp.AddLines(myDonut.ToArray());
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            using (PathGradientBrush b = new PathGradientBrush(gp))
            {
                b.CenterPoint = new PointF(midx, midy);
                b.CenterColor = Color.White;
                b.SurroundColors = myPieColor;
                e.Graphics.FillPath(b, gp);
            }
        }
    }
