using System;
using Ozeki.Media;
 
namespace Acoustic_Echo_Cancellation
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
 
            audioProcessor.AcousticEchoCancellation = true; // acoustic echo cancellation is enabled
            audioProcessor.SetEchoSource(speaker);  // sets the speaker to be the source of the echo
 
            connector.Connect(microphone, audioProcessor);  // voice data is being sent through the enhancer
            connector.Connect(audioProcessor, speaker);
 
            audioProcessor.Start();
            microphone.Start();
            speaker.Start();
 
            Console.ReadLine();
        }
    }
}
visit:http://www.voip-sip-sdk.com/p_373-how-to-implement-voip-acoustic-echo-cancellation-voip.html for more information
