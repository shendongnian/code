        private byte[] TensorToBitmap(TFTensor image)
        {
            var graph = new TFGraph();
            var input = graph.Placeholder(TFDataType.Float);
            var output = graph.Cast(input, TFDataType.UInt8);
            output = graph.EncodeJpeg(output);
            using (var session = new TFSession(graph))
            {
                var result = session.Run(
                    inputs: new[] { input },
                    inputValues: new[] { image },
                    outputs: new[] { output });
                var tensor = result[0];
                byte[] buffer = new byte[(int)tensor.TensorByteSize - 10];
                System.Runtime.InteropServices.Marshal.Copy(tensor.Data + 10, buffer, 0, buffer.Length);
                return buffer;
            }
        }
