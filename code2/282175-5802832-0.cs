    /// <summary>
    /// Animation helper class.
    /// </summary>
    public class Animation
    {
        List<Keyframe> keyframes = new List<Keyframe>();
        int timeline;
        int lastFrame = 0;
        bool run = false;
        int currentIndex;
        /// <summary>
        /// Construct new animation helper.
        /// </summary>
        public Animation()
        {
        }
        public void AddKeyframe(int time, float value)
        {
            Keyframe k = new Keyframe();
            k.time = time;
            k.value = value;
            keyframes.Add(k);
            keyframes.Sort(delegate(Keyframe a, Keyframe b) { return a.time.CompareTo(b.time); });
            lastFrame = (time > lastFrame) ? time : lastFrame;
        }
        public void Start()
        {
            timeline = 0;
            currentIndex = 0;
            run = true;
        }
        public void Update(GameTime gameTime, ref float value)
        {
            if (run)
            {
                timeline += gameTime.ElapsedGameTime.Milliseconds;
                value = MathHelper.SmoothStep(keyframes[currentIndex].value, keyframes[currentIndex + 1].value, (float)timeline / (float)keyframes[currentIndex + 1].time);
                if (timeline >= keyframes[currentIndex + 1].time && currentIndex != keyframes.Count) { currentIndex++; }
                if (timeline >= lastFrame) { run = false; }
            }
        }
        public struct Keyframe
        {
            public int time;
            public float value;
        }
    }
