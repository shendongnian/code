    using UnityEngine.Audio;
    using System;
    using UnityEngine;
    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;
    
        public static AudioManager instance;
    
        void Awake() { ... }
        void Start() { ... }
    
        public void Play(string name) { ... }
    
        public void Stop(string name) {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + "not found!");
                return;
            }
    
            s.source.Stop();
        }
    }
