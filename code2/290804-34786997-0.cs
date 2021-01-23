    var flowResult = new Mat();
    CvInvoke.CalcOpticalFlowFarneback(_scaledDownFrameOneColorImagePrev, scaledDownFrameOneColorImage, flowResult, 0.25, 3, 15, 5, 1, 1.2, OpticalflowFarnebackFlag.Default);
    var flowResultChannels = flowResult.Split();
    var flowResultX = flowResultChannels[0];
    var flowResultY = flowResultChannels[1];
    for (var r = 0; r < flowResult.Rows; r++)
    {
        for (var c = 0; c < flowResult.Cols; c++)
        {
            var xValue = new float[1];
            Marshal.Copy(flowResultX.DataPointer + (((r * flowResultX.Cols) + c) * flowResultX.ElementSize), xValue, 0, 1);
            var yValue = new float[1];
            Marshal.Copy(flowResultY.DataPointer + (((r * flowResultY.Cols) + c) * flowResultY.ElementSize), yValue, 0, 1);
            if (Math.Abs(xValue[0]) > 3 || Math.Abs(yValue[0]) > 3)
            {
                Console.WriteLine("{0} {1}", xValue[0], yValue[0]);
            }
        }
    }
