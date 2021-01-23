    public double MeasureDecibels(byte[] samples, int length, int bitsPerSample,
            int numChannels, params int[] channelsToMeasure)
        {
            if (samples == null || length == 0 || samples.Length == 0)
            {
                throw new ArgumentException("Missing samples to measure.");
            }
            //check bits are 8 or 16.
            if (bitsPerSample != 8 && bitsPerSample != 16)
            {
                throw new ArgumentException("Only 8 and 16 bit samples allowed.");
            }
            //check channels are valid
            if (channelsToMeasure == null || channelsToMeasure.Length == 0)
            {
                throw new ArgumentException("Must have target channels.");
            }
            //check each channel is in proper range.
            foreach (int channel in channelsToMeasure)
            {
                if (channel < 0 || channel >= numChannels)
                {
                    throw new ArgumentException("Invalid channel requested.");
                }
            }
            //ensure we have only full blocks. A half a block isn't considered valid.
            int sampleSizeInBytes = bitsPerSample / 8;
            int blockSizeInBytes = sampleSizeInBytes * numChannels;
            if (length % blockSizeInBytes != 0)
            {
                throw new ArgumentException("Non-integral number of bytes passed for given audio format.");
            }
            double sum = 0;
            for (var i = 0; i < length; i = i + blockSizeInBytes)
            {
                double sumOfChannels = 0;
                for (int j = 0; j < channelsToMeasure.Length; j++)
                {
                    int channelOffset = channelsToMeasure[j] * sampleSizeInBytes;
                    int channelIndex = i + channelOffset;
                    if (bitsPerSample == 8)
                    {
                        sumOfChannels = (127 - samples[channelIndex]) / byte.MaxValue;
                    }
                    else
                    {
                        double sampleValue = BitConverter.ToInt16(samples, channelIndex);
                        sumOfChannels += (sampleValue / short.MaxValue);
                    }
                }
                double averageOfChannels = sumOfChannels / channelsToMeasure.Length;
                sum += (averageOfChannels * averageOfChannels);
            }
            int numberSamples = length / blockSizeInBytes;
            double rootMeanSquared = Math.Sqrt(sum / numberSamples);
            if (rootMeanSquared == 0)
            {
                return 0;
            }
            else
            {
                double logvalue = Math.Log10(rootMeanSquared);
                double decibel = 20 * logvalue;
                return decibel;
            }
        }
