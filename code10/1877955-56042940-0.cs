sigma = data;
As you can see they're no longer loops, because sigma now contains only "solution" coordinates (which are Z coords), so I need to just assign data array to sigma.
Second part, where I'm creating Surface now looks like this:
var B = ILMath.tosingle(sigma);
var scene = new PlotCube(twoDMode: false) {
         // add a surface
         new Surface(B) {
                 // make thin transparent wireframes
                 Wireframe = { Color = Color.FromArgb(50, Color.LightGray) },
                 // choose a different colormap
                 Colormap = Colormaps.Jet,
         }
};
scene.Axes.XAxis.Max = (float)arguments[0].Maximum;
scene.Axes.XAxis.Min = (float)arguments[0].Minimum;
scene.Axes.YAxis.Max = (float)arguments[1].Maximum;
scene.Axes.YAxis.Min = (float)arguments[1].Minimum;
scene.First<PlotCube>().Rotation = Matrix4.Rotation(new Vector3(1f, 0.23f, 1), 0.7f);
Basically one thing which changed is scaling XY axes to proper values.
# Final results #
Here you have final results:
![heart](https://i.imgur.com/WmWSOaF.png)
