// GET api/music
public async System.Threading.Tasks.Task<string> GetAsync()
{
   	string result = await MusicHandler.MusicCapture.DetectAsync(5);
   	Console.WriteLine("Server returning: " + result);
   	return result;
}
