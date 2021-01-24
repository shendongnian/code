    using System;
    using Ozeki.Media;
    
    namespace Automatic_Gain_Control
    {
    	class Program
    	{
    		static Microphone microphone;
    		static Speaker speaker;
    		static MediaConnector connector;
    		static AudioQualityEnhancer audioProcessor;
    
    		static void Main(string[] args)
    		{
    			microphone = Microphone.GetDefaultDevice();
    			speaker = Speaker.GetDefaultDevice();
    			connector = new MediaConnector();
    			audioProcessor = new AudioQualityEnhancer();
    
    			audioProcessor.AutoGainControl = true;//enable
    			audioProcessor.GainSpeed = 12;
    			audioProcessor.MaxGain = 30;
    
    			connector.Connect(microphone, audioProcessor);
    			connector.Connect(audioProcessor, speaker);
    
    			microphone.Start();
    			speaker.Start();
    
    			Console.ReadLine();
    		}
    	}
    }
