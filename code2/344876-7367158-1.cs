float RotDegrees = 90;                // Centerline angle for wedge
float width = 10.0;                   // Assume a 10 degree wedge
// Center of view
PointF PitCenter = new PointF(picBoxZoomMap.Width / 2,
                              picBoxZoomMap.Height / 2);
// Determine the angle for the wedges in radians
float theta0 = (RotDegrees - width / 2.0) * Math.PI / 180.0;
float theta1 = (RotDegrees + width / 2.0) * Math.PI / 180.0;
// May need to adjust this to satisfy your needs 
float radius = 100.0;
// Determine the endpoints of the new wedge
PointF p0 = new PointF( radius * Math.Cos(theta0) + PitCenter.X,
                        radius * Math.Sin(theta0) + PitCenter.Y);
PointF p1 = new PointF( radius * Math.Cos(theta1) + PitCenter.X,
                        radius * Math.Sin(theta1) + PitCenter.Y);
// Draw the lines
zoomgfx.DrawLine(Pens.Red, PitCenter, p0);
zoomgfx.DrawLine(Pens.Red, PitCenter, p1);
