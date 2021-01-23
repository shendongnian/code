            GraphicsPath graphicsPath = new GraphicsPath();
            float[] x = new float[4];
            float[] y = new float[4];
            string prev = "";
            string[] splits = svgString.Split(' ');
            for (int s = 0; s < splits.Length; s++)
            {
                if (splits[s].Substring(0, 1) == "M")
                {
                    x[0] = float.Parse(splits[s].Substring(1).Replace('.', ','));
                    y[0] = float.Parse(splits[s + 1].Replace('.', ','));
                    s++;
                    prev = "M";
                    graphicsPath.StartFigure();
                }
                else if (splits[s].Substring(0, 1) == "L")
                {
                    x[1] = float.Parse(splits[s].Substring(1).Replace('.', ','));
                    y[1] = float.Parse(splits[s + 1].Replace('.', ','));
                    graphicsPath.AddLine(new PointF(x[0], y[0]), new PointF(x[1], y[1]));
                    x[0] = x[1]; // x[1] = new float();
                    y[0] = y[1]; //y[1] = new float();
                    s++;
                    prev = "L";
                }
                else if (splits[s].Substring(0, 1) == "Q")
                {
                    x[1] = x[0] + (2 / 3) * (float.Parse(splits[s].Substring(1).Replace('.', ',')) - x[0]);
                    y[1] = y[0] + (2 / 3) * (float.Parse(splits[s + 1].Replace('.', ',')) - y[0]);
                    x[3] = float.Parse(splits[s + 2].Replace('.', ','));
                    y[3] = float.Parse(splits[s + 3].Replace('.', ','));
                    x[2] = x[3] + (2 / 3) * (float.Parse(splits[s].Substring(1).Replace('.', ',')) - y[3]);
                    y[2] = y[3] + (2 / 3) * (float.Parse(splits[s + 1].Replace('.', ',')) - y[3]);
                    graphicsPath.AddBezier(new PointF(x[0], y[0]), new PointF(x[1], y[1]), new PointF(x[2], y[2]), new PointF(x[3], y[3]));
                    x[0] = x[3]; 
                    y[0] = y[3]; 
                    s = s + 3;
                    prev = "Q";
                }
                else if (splits[s].Substring(0, 1) == "Z")
                {
                    graphicsPath.CloseFigure();
                    if (splits[s].Length >= 2 && splits[s].Substring(0, 2) == "ZM")
                    {
                        x[0] = float.Parse(splits[s].Substring(2).Replace('.', ','));
                        y[0] = float.Parse(splits[s + 1].Replace('.', ','));
                        s++;
                        graphicsPath.StartFigure();
                        prev = "M";
                    }
                }
                else
                {
                    string ok = @"^[a-zA-Z]*$";
                    if (!Regex.IsMatch(splits[s + 1].Substring(0, 1), ok))
                    {
                        string replace = prev + splits[s + 1];
                        splits[s + 1] = replace;
                    }
                }
            }
            return graphicsPath;
        }
