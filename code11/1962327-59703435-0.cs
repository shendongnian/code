            KalmanFilter tracker = new KalmanFilter(4, 1, 0);
            var transitionMatrix = new Matrix<float>(new[,]
            {
                {1f, 1f, 0f, 0f},
                {0, 1, 1, 0},
                {0, 0, 1, 1},
                {0, 0, 0, 1}
            });
            var measurementMatrix = new Matrix<float>(new[,] { { 1f, 0, 0, 0 } });
   
            var procNoiseCov = new Matrix<float>(4, 4);
            procNoiseCov.SetIdentity(new MCvScalar(processNoise));
            var measurementNoise = new Matrix<float>(1, 1);
            measurementNoise.SetIdentity(new MCvScalar(measurementNoiseValue));
            var errorCovPost = new Matrix<float>(4, 4);
            errorCovPost.SetIdentity(new MCvScalar(10));
            transitionMatrix.Mat.CopyTo(tracker.TransitionMatrix);
            measurementMatrix.Mat.CopyTo(tracker.MeasurementMatrix);
            procNoiseCov.Mat.CopyTo(tracker.ProcessNoiseCov);
            measurementNoise.Mat.CopyTo(tracker.MeasurementNoiseCov);
            errorCovPost.Mat.CopyTo(tracker.ErrorCovPost);
            tracker.StatePost.SetTo(new float[] { 0, 1, 1, 1 });
            
            List<float> result = new List<float>();
            Matrix<float> corrected = new Matrix<float>(4, 1);
            
            foreach (var z in values)
            { 
                tracker.Correct(measurement.Mat).CopyTo(corrected);
                tracker.Predict();
                states.Add(corrected[0,0]);
            }
            return states;
It's not _exactly_ the same, but it's stable and good enough for me right now.
