        public override void Process(VstAudioBuffer[] inChannels, VstAudioBuffer[] outChannels)
        {
            VstAudioBuffer audioChannel = outChannels[0];
            for (int n = 0; n < audioChannel.SampleCount; n++)
            {
                audioChannel[n] = Delay.ProcessSample(inChannels[0][n]);
            }
        }
