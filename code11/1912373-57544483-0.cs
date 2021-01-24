    using System;
    using System.Collections.Generic;
    using UnityEngine;
    [Serializable]
    public class Letter
    {
	    [Serializable]
	    public struct LetterSounds
	    {
		    public Sprite sprite;
		    public AudioClip audioClip;
	    }
	    public Sprite mainSprite;
	    public List<LetterSounds> letterSounds = new List<LetterSounds>();
	    public Animation animation;
    }
    public class AlphaIntroController : MonoBehaviour 
    {
	    public List<Letter> letters = new List<Letter>();
    }
