cs
public void Start()
{
    LogSystem.InstallDefaultReactors();
    textToSpeech = new TextToSpeechService();
    while (!textToSpeech.Credentials.HasIamTokenData())
        yield return null;
    Runnable.Run(Synthesize("Hello world!"));
}
public IEnumerator Synthesize(string text)
{
    byte[] synthesizeResponse = null;
    AudioClip clip = null;
    textToSpeech.Synthesize(
        callback: (DetailedResponse<byte[]> response, IBMError error) =>
        {
            synthesizeResponse = response.Result;
            clip = WaveFile.ParseWAV("myClip", synthesizeResponse);
            PlayClip(clip);
        },
        text: text,
        voice: "en-US_AllisonVoice",
        accept: "audio/wav"
    );
    while (synthesizeResponse == null)
        yield return null;
    yield return new WaitForSeconds(clip.length);
}
