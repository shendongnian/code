// detect face landmark points.
OpenCVForUnityUtils.SetImage(faceLandmarkDetector, rgbaMat);
for (int i = 0; i < trackedRects.Count; i++)
{
  List<Vector2> points = faceLandmarkDetector.DetectLandmark(rect);
  List<Vector2> pointss = new List<Vector2>();
  //Draw Contours
  List<Point> pointsss = OpenCVForUnityUtils.ConvertVector2ListToPointList(pointss);
  MatOfPoint hullPointMat = new MatOfPoint();
  hullPointMat.fromList(pointsss);
  List<MatOfPoint> hullPoints = new List<MatOfPoint>();
  hullPoints.Add(hullPointMat);
  Imgproc.drawContours(rgbaMat, hullPoints, -1, new Scalar(150, 100, 5,255), -1);
}
