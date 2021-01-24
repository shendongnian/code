	[RequireComponent(typeof(UnityEngine.Video.VideoPlayer))]
	public class MyVideoPlayer : MonoBehaviour
	{
		[SerializeField]
		private System.Collections.Generic.List<UnityEngine.Video.VideoClip> videoClips = null;
		private UnityEngine.Video.VideoPlayer videoPlayer = null;
		private IEnumerator playEnumerator = null;
		public void VideoPlay(int num)
		{
			Application.runInBackground = true;
			playEnumerator = VideoPlayCoroutine(num);
			StartCoroutine(playEnumerator);
		}
		public void VideoStop()
		{
			videoPlayer.Stop();
			if (playEnumerator != null)
			{
				StopCoroutine(playEnumerator);
			}
		}
		private System.Collections.IEnumerator VideoPlayCoroutine(int num)
		{
			videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
			Debug.Assert(videoClips.Count > num);
			Debug.Assert(videoClips[num] != null);
			videoPlayer.clip = videoClips[num];
			videoPlayer.Prepare();
			while (!videoPlayer.isPrepared)
			{
				Debug.Log("Preparing Video");
				yield return null;
			}
			Debug.Log("Done Preparing Video");
			videoPlayer.Play();
			while (videoPlayer.isPlaying)
			{
				yield return null;
			}
			Debug.Log("Played Successfully!!");
		}
	}
