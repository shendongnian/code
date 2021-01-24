        private byte[] YuvToRgbOpenCv(object luma, object chroma, object yData, object uData, object vData)
        {
            int[] lumaArray = (int[])luma;
            int[] chromaArray = (int[])chroma;
            int lumaWidth = lumaArray[0];
            int lumaHeight = lumaArray[1];
            int chromaWidth = chromaArray[0];
            int chromaHeight = chromaArray[1];
            byte[] y = (byte[])yData;
            byte[] u = (byte[])uData;
            byte[] v = (byte[])vData;
            var ym = new Mat(new[] { lumaHeight, lumaWidth }, MatType.CV_8UC1, y);
            var um = new Mat(new[] { chromaHeight, chromaWidth }, MatType.CV_8UC1, u);
            var vm = new Mat(new[] { chromaHeight, chromaWidth }, MatType.CV_8UC1, v);
            var umResized = um.Resize(new OpenCvSharp.Size(lumaWidth, lumaHeight), 0, 0, InterpolationFlags.Nearest);
            var vmResized = vm.Resize(new OpenCvSharp.Size(lumaWidth, lumaHeight), 0, 0, InterpolationFlags.Nearest);
            var yuvMat = new Mat();
            var resizedChannels = new[] { ym, umResized, vmResized };
            Cv2.Merge(resizedChannels, yuvMat);
            var bgr = yuvMat.CvtColor(ColorConversionCodes.YUV2BGR);
            var result = bgr.ToBytes();
            return result;
        }
