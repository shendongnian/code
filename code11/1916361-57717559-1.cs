c#
public class AudioTrigger : MonoBehaviour {
    #region Fields
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private List<Collider> _targetColliders;
    #endregion
    #region Properties
    public AudioSource AudioSource {
        get => _audioSource;
        set => _audioSource = value;
    }
    public AudioClip AudioClip {
        get => _audioClip;
        set => _audioClip = value;
    }
    public List<Collider> TargetColliders => _targetColliders;
    #endregion
    #region Methods
    #region Instance Methods
    private void OnTriggerEnter(Collider other) {
        if (TargetColliders.Count == 0 || TargetColliders.Contains(other))
            AudioSource.PlayOneShot(AudioClip);
    }
    private void OnTriggerExit(Collider other) {
        if (TargetColliders.Count == 0 || TargetColliders.Contains(other)) {
            AudioSource.Stop();
            AudioSource.PlayOneShot(AudioClip);
        }
    }
    #endregion
    #endregion
}
There, now you can just plug that script in wherever and whenever you need a trigger to play audio, be it on any trigger event (by setting no target colliders) or on enter and exit events by specific "target" colliders.
This can be further modularized to work as a trigger for any action or set of actions, not just audio, by using [`UnityEvent`][1]. But I'll leave that as an exercise for you.
  [1]: https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html
