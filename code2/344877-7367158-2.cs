float RotDegrees = 90.0;              // Centerline angle for wedge
float width = 10.0;                   // Assume a 10 degree wedge
// Center of view
PointF PitCenter = new PointF(picBoxZoomMap.Width / 2,
                              picBoxZoomMap.Height / 2);
// Determine the angle for the wedges in radians
float theta0 = (RotDegrees - width / 2.0) * Math.PI / 180.0;
float theta1 = (RotDegrees + width / 2.0) * Math.PI / 180.0;
// May need to adjust this to satisfy your needs 
float radius = 100.0;
// Determine the endpoints of the new wedge ... Assumes (0,0) is in the upper
// left corner rather than the lower left (where it belongs ;).  If it's in the
// lower left after all, change the subtraction in the Y components to an
// addition
PointF p0 = new PointF( PitCenter.X + radius * Math.Cos(theta0),
                        PitCenter.Y - radius * Math.Sin(theta0) );
PointF p1 = new PointF( PitCenter.X + radius * Math.Cos(theta1),
                        PitCenter.Y - radius * Math.Sin(theta1));
// Draw the lines
zoomgfx.DrawLine(Pens.Red, PitCenter, p0);
zoomgfx.DrawLine(Pens.Red, PitCenter, p1);
