public static async void ConvertMp4ToMp3(byte[] mp4Data, Action<Stream> doneCallback) {
    MediaEncodingProfile profile = MediaEncodingProfile.CreateMp3(AudioEncodingQuality.High);
    var inputStream = new MemoryRandomAccessStream(mp4Data);
    var outputStream = new InMemoryRandomAccessStream();
    MediaTranscoder transcoder = new MediaTranscoder();
    PrepareTranscodeResult prepareOperation = await transcoder.PrepareStreamTranscodeAsync(inputStream, outputStream, profile);
    if (prepareOperation.CanTranscode) {
        //start to convert
        var transcodeOperation = prepareOperation.TranscodeAsync();
        //registers completed event handler 
        transcodeOperation.Completed += (IAsyncActionWithProgress<double> asyncInfo, AsyncStatus status) => {
            asyncInfo.GetResults();
            var stream = outputStream.AsStream();
            stream.Position = 0;
            doneCallback(stream);
        };
    } else {
        doneCallback(null);
    }
}
The imports:
using System;
using System.IO;
using Windows.Foundation;
using Windows.Media.MediaProperties;
using Windows.Media.Transcoding;
using Windows.Storage.Streams;
And the `MemoryRandomAccessStream` is just an implementation of the `IRandomAccesStream` interface and can be found [here][1].
  [1]: https://canbilgin.wordpress.com/2012/06/06/how-to-convert-byte-array-to-irandomaccessstream/
