    var tapLocation = gestureRecognize.LocationInView(SceneView);
    var hitTestResults = SceneView.HitTest(tapLocation, ARHitTestResultType.EstimatedHorizontalPlane);
    
    var hitTestResult = hitTestResults.FirstOrDefault();
    if (hitTestResult == null) return;
    var position = new SCNVector3(hitTestResult.WorldTransform.Column3.X, hitTestResult.WorldTransform.Column3.Y, hitTestResult.WorldTransform.Column3.Z);
    planeNode.Position = position;
